using Agrades.Api.ApiModels.Adresses;
using Agrades.Api.ApiModels.Persons;
using Agrades.Api.ApiModels.XML;
using Agrades.Api.Mapper;
using Agrades.Api.Utilities;
using Agrades.Data;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Categories;
using Agrades.Data.Entities.Persons;
using Agrades.Data.Interfaces;
using Agrades.Services;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using NodaTime;
using NodaTime.Text;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Agrades.Api.Controllers;
[ApiController]
public class RecordController : ControllerBase
{
    private readonly ILogger<RecordController> _logger;
    private readonly AppDbContext _dbContext;
    private readonly ICurrentOperationService _currentOperationService;
    private readonly IAppMapper _mapper;
    private readonly IClock _clock;

    public RecordController(
        ILogger<RecordController> logger,
        AppDbContext dbContext,
        ICurrentOperationService currentOperationService,
        IAppMapper mapper,
        IClock clock
        )
    {
        _logger = logger;
        _dbContext = dbContext;
        _currentOperationService = currentOperationService;
        _mapper = mapper;
        _clock = clock;
    }
    

    [HttpPost("api/v1/{opUrlName}/report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> XMLReport([FromRoute] string opUrlName, [FromQuery] string? since = null, [FromQuery] string? until = null)
    {
        var now = _clock.GetCurrentInstant();

        var currentYear = now.ToDateTimeUtc().Year;

        var thisYearsFirstSeptember = Instant.FromDateTimeUtc(new DateTime(currentYear, 9, 1, 0, 0, 0, DateTimeKind.Utc));
        var operation = _dbContext.Operations.FirstOrDefault(x => x.UrlName == opUrlName);
        if (operation == null)
        {
            return NotFound("Operation not found.");
        }
        var sinceDate = since != null ? Instant.FromDateTimeUtc(DateTime.Parse(since).ToUniversalTime()) : Instant.FromUtc(DateTime.Now.Year - 1, 9, 1, 0, 0);
        Instant? untilDate = until != null ? Instant.FromDateTimeUtc(DateTime.Parse(until).ToUniversalTime()) : null;
        var persons = _dbContext.Persons.FilterByOperation(operation.Id).ToList();
        var personDetails = _dbContext.PersonDetails.FilterByOperation(operation.Id).ToList();
        var students = _dbContext.Students.FilterByOperation(operation.Id).ToList();
        var studentDetails = _dbContext.StudentDetails.FilterByOperation(operation.Id).FilterByInterval(sinceDate, untilDate).ToList();
        var studyFields = _dbContext.StudyFields.FilterByOperation(operation.Id).ToList();
        var addresses = _dbContext.Addresses.FilterByOperation(operation.Id).ToList();
        var virtualOperations = _dbContext.VirtualOperations.ToList();
        var classes = _dbContext.Classes.ToList();
        var classDetails = _dbContext.ClassDetails.ToList();


        var sentences = new List<Sentence>();
        foreach (var student in students)
        {
            var thisStudentStudentDetails = studentDetails.Where(x => x.StudentId == student.Id
            && (x.ValidUntil <= untilDate
                || x.ValidUntil == untilDate
                || x.ValidSince == (untilDate + Duration.FromDays(1)))
            && (x.ValidSince >= sinceDate)).ToList();
            foreach (var studentDetail in thisStudentStudentDetails)
            {
                var person = persons.First(x => x.Id == student.PersonId);
                var personDetail = personDetails.First(x => x.PersonId == person.Id && (x.ValidUntil <= untilDate || x.ValidUntil == untilDate));
                var studyField = studyFields.First(x => x.Id == studentDetail.StudyFieldId);
                var address = addresses.First(x => x.Id == personDetail.PermanentAddressId);
                var virtualOperation = virtualOperations.First(x => x.Id == studentDetail.PreviousEducationOperationId && x.OperationId == operation.Id);
                var studentClass = classes.First(x => x.Id == studentDetail.ClassId);
                var classDetail = classDetails.First(x => x.ClassId == studentClass.Id && (x.ValidUntil <= untilDate || x.ValidUntil == untilDate));
                var grade = now > thisYearsFirstSeptember
                    ? currentYear - studentDetail.Class!.ClassDetails.Single(x => x.ValidUntil == null).StartAt.Year + 1
                    : currentYear - studentDetail.Class!.ClassDetails.Single(x => x.ValidUntil == null).StartAt.Year;

                sentences.Add(SentenceExtensions.ToSentence(_mapper, personDetail, studentDetail, studyField, operation, address, virtualOperation, classDetail, grade, untilDate));
            }
        }
        var path = "sentence.xml";
        var sww = new StreamWriter(path);

        XmlWriter writer = XmlWriter.Create(sww);
        XmlSerializer xmlSerializer = new XmlSerializer(sentences.GetType(), new XmlRootAttribute("sentences"));
        xmlSerializer.Serialize(writer, sentences);
        sww.Close();

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(path, out var contentType))
        {
            contentType = "text/xml";
        }

        var bytes = System.IO.File.ReadAllBytes(path);
        return File(bytes, contentType, path);
    }

    [HttpPost("api/v1/{opUrlName}/Record/{personId}/CreateNewVersion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateNewVersion(
        [FromRoute] string opUrlName,
        [FromRoute] Guid personId,
        [FromQuery] bool? newPermanentAddress
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);

        if (currentOp == null)
        {
            return NotFound("Operation not found.");
        }

        var now = _clock.GetCurrentInstant();

        var person = await _dbContext.Persons.FilterByOperation(currentOp.Id).SingleOrDefaultAsync(x => x.Id == personId);

        if (person == null)
        {
            return NotFound("PersonId not found");
        }

        // We want to break as soon as possible if there is more then one "active" details
        var personDetail = await _dbContext.PersonDetails
            .SingleAsync(x => x.PersonId == person.Id && x.ValidUntil != null);

        personDetail.ValidUntil = now;
        personDetail.SetModifyBySystem(now);

        // I don't want to think about overlaping yet
        now = _clock.GetCurrentInstant();

        // This shouldn't be this hard. Memberwise cloning or something
        var newPersonDetail = new PersonDetail
        {
            BackofficeNote = personDetail.BackofficeNote,
            BirthAddress = personDetail.BirthAddress,
            BirthAddressId = personDetail.BirthAddressId,
            BirthName = personDetail.BirthName,
            BornOn = personDetail.BornOn,
            Citizenship = personDetail.Citizenship,
            CitizenshipCode = personDetail.CitizenshipCode,
            // addresses has wrong relationship in navicat ERD
            // or is this wrong? Should I create new address? 
            ContactAddressId = personDetail.ContactAddressId,
            DataBox = personDetail.DataBox,
            DegreesPost = personDetail.DegreesPost,
            DegreesPre = personDetail.DegreesPre,
            FamilyStatusId = personDetail.FamilyStatusId,
            IdentificationCode = personDetail.IdentificationCode,
            FirstName = personDetail.FirstName,
            IdentificationCodeTypeId = personDetail.IdentificationCodeTypeId,
            IdentityCardNumber = personDetail.IdentityCardNumber,
            IdentityCardNumberTypeId = personDetail.IdentityCardNumberTypeId,
            InactivityReasonId = personDetail.InactivityReasonId,
            InsuranceCompanyCode = personDetail.InsuranceCompanyCode,
            OperationId = personDetail.OperationId,
            OrganizationUniqueCode = personDetail.OrganizationUniqueCode,
            PermanentAddressId = personDetail.PermanentAddressId,
            LastName = personDetail.LastName,
            PersonId = personId,
            Sex = personDetail.Sex,
            StatusId = personDetail.StatusId,
            TemporaryAddressId = personDetail.TemporaryAddressId,
            ValidSince = now,
        }.SetCreateBySystem(now);

        if (newPermanentAddress != null && newPermanentAddress.Value)
        {
            var oldAddress = await _dbContext.Addresses.SingleAsync(x => x.Id == personDetail.PermanentAddressId);
            oldAddress.ValidUntil = now;
            now = _clock.GetCurrentInstant();
            personDetail.PermanentAddress = new Address
            {
                OperationId = oldAddress.OperationId,
                City = oldAddress.City,
                CityDistrict = oldAddress.CityDistrict,
                DescNumber = oldAddress.DescNumber,
                OriNumber = oldAddress.OriNumber,
                Email = oldAddress.Email,
                Region = oldAddress.Region,
                PhoneNumber = oldAddress.PhoneNumber,
                State = oldAddress.State,
                StateDistrict = oldAddress.StateDistrict,
                Street = oldAddress.Street,
                ZipCode = oldAddress.ZipCode,
                ValidSince = now
            }.SetCreateBySystem(now);
        }

        person.PersonDetails.Add(newPersonDetail);
        person.RowCount++;

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("/api/v1/{opUrlName}/Record/ImportStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> ImportCsv(
        [FromRoute] string opUrlName,
        [FromBody] ImportModel model
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);
        var now = _clock.GetCurrentInstant();
        var lines = model.Data.ToList();
        var classes = _dbContext.Classes.ToList();

        var classDetails = _dbContext.ClassDetails.ToList();

        // skip table header
        for (int i = 1; i < lines.Count; i++)
        {
            var values = lines[i].Split(';');

            var birthDate = new DateTime(int.Parse(values[10].Split('.')[2]), int.Parse(values[10].Split('.')[1]), int.Parse(values[10].Split('.')[0]), 0, 0, 0, DateTimeKind.Utc);

            var startsAt = Instant.FromDateTimeUtc(new DateTime(int.Parse(values[50].Split('.')[2]), int.Parse(values[50].Split('.')[1]), int.Parse(values[50].Split('.')[0]), 0, 0, 0, DateTimeKind.Utc));

            var personDetail = new PersonDetail
            {
                OperationId = currentOp!.Id,
                OrganizationUniqueCode = values[0],
                LastName = values[1],
                FirstName = values[2],
                InsuranceCompanyCode = values[7],
                IdentificationCode = values[8],
                IdentificationCodeTypeId = UniqueCodeType.BirthNumber,
                Sex = values[9] == "Muž" ? Sex.Male : Sex.Female,
                BornOn = LocalDate.FromDateTime(birthDate),
                CitizenshipCode = values[11],
                Citizenship = values[12],
                ValidSince = startsAt,
            }.SetCreateBySystem(now);

            var birthAddress = new Address
            {
                OperationId = currentOp.Id,
                City = values[6],
                ValidSince = startsAt,
            }.SetCreateBySystem(now);

            _dbContext.Add(birthAddress);

            personDetail.BirthAddress = birthAddress;

            var addr = values[5].Split(',');
            var addrParts = addr[0].Split(' ');
            var street = string.Join(' ', addrParts.Take(addrParts.Length - 1));
            var zipCity = addr[1].Trim().Split(' ');

            var permAddress = new Address
            {
                OperationId = currentOp.Id,
                Street = street,
                DescNumber = addrParts[^1],
                Email = values[3],
                PhoneNumber = values[4],
                CityDistrict = string.Join(' ', zipCity.Take(new Range(2, zipCity.Length))),
                StateDistrict = values[14],
                ZipCode = zipCity[0] + " " + zipCity[1],
                City = values[13],
                State = values[12], // this is not state for current address
                ValidSince = startsAt,
            }.SetCreateBySystem(now);

            _dbContext.Add(permAddress);

            personDetail.PermanentAddress = permAddress;

            // We need Local property, because we need entities which are could be created but are not in database yet,
            // they are in memory until SaveChanges
            var prevOp = _dbContext.VirtualOperations.Local.SingleOrDefault(x => x.IdentificationCode == values[16]);

            if (prevOp == null)
            {
                prevOp = new VirtualOperation
                {
                    OperationId = currentOp.Id,
                    IdentificationCode = values[16],
                    IdentificationCodeTypeId = UniqueCodeType.Izo,
                    ValidSince = startsAt,
                }.SetCreateBySystem(now);

                _dbContext.Add(prevOp);
            }

            var studentDetail = new StudentDetail
            {
                OperationId = currentOp.Id,
                StartsAt = LocalDate.FromDateTime(startsAt.ToDateTimeUtc()),
                ObligatoryAttendenceYears = 9,
                Financing = 1,
                PreviousEducationCode = values[15],
                PreviousEducationOperationId = prevOp.Id,
                StartReasonCode = values[19],
                HighestAchievedEducation = FieldOfStudyType.ElementarySchool,
                StudyFieldId = DatabaseConstants.ITG.FieldOfStudyId,
                ValidSince = startsAt,
            }.SetCreateBySystem(now);

            var person = new Person
            {
                PersonTypeId = PersonType.Student,
                RowCount = 1,
                OperationId = currentOp.Id,
            };

            _dbContext.Add(person);

            var student = new Student
            {
                RowCount = 1,
                OperationId = currentOp.Id,
            };

            _dbContext.Add(student);

            person.Student = student;

            person.PersonDetails.Add(personDetail);
            _dbContext.Add(personDetail);
            student.StudentDetails.Add(studentDetail);
            _dbContext.Add(studentDetail);

            var c = values[27].Split('.')[1];

            // consider create and use NormalizedName
            var currentClassId = classDetails.Single(x => x.Name.ToLower() == c.ToLower()).ClassId;
            var currentClass = classes.Single(x => x.Id == currentClassId);

            studentDetail.ClassId = currentClass.Id;

            /*currentClass.Groups.First().Students.Add(new StudentGroup
            {
                StudentId = student.Id,
                ValidSince = now,
            }.SetCreateBySystem(now));*/
#if DEBUG
            Print(values);
#endif
        }

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private void Print(string[] values)
    {
        for (int j = 0; j < 32; j++)
        {
            Console.WriteLine($"{j}:{(string.IsNullOrEmpty(values[j]) ? "==========================================================" : values[j])}");
        }
    }

    public record ImportModel
    {
        public IEnumerable<string> Data { get; set; } = null!;
    }

    [HttpGet("/api/v1/{opUrlName}/Record/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentRecordDetail>> Get(
        [FromRoute] string opUrlName,
        [FromRoute] Guid id
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);

        if (currentOp == null)
        {
            return NotFound("Operation not found.");
        }

        var person = await _dbContext.Persons
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (person == null)
        {
            return NotFound("Person not found.");
        }

        var personDetail = await _dbContext.Set<PersonDetail>()
            .Where(x => x.PersonId == id)
            .OrderByDescending(x => x.ValidSince)
            .FirstOrDefaultAsync();

        if (personDetail == null)
        {
            return NotFound();
        }

        return Ok(_mapper.ToDetail(personDetail));
    }

    /// <summary>
    /// PersonTypes (currently just Student, workin on Teacher)
    ///     Student = 101,
    ///     Teacher = 201,
    ///     OtherEmployee = 202,
    ///     LegalGuardian = 301,
    /// </summary>
    /// <param name="opUrlName"></param>
    /// <param name="personType"></param>
    /// <returns></returns>
    [HttpGet("/api/v1/{opUrlName}/Record")]
    public async Task<ActionResult> GetList(
        [FromRoute] string opUrlName,
        [FromQuery] int? personType
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);

        if (currentOp == null)
        {
            return NotFound("Operation not found");
        }

        var now = _clock.GetCurrentInstant();

        var personIds = _dbContext
            .Persons
            .Where(x => x.PersonTypeId == PersonType.Student && x.OperationId == currentOp!.Id)
            .Select(x => x.Id)
            .ToList();

        var students = _dbContext
            .Students
            .Where(x => personIds.Contains(x.PersonId) && x.OperationId == currentOp!.Id)
            .ToList()
            ;

        var studentIds = students.Select(x => x.Id);

        var personDetails = _dbContext
            .PersonDetails
            .Where(x => personIds.Contains(x.PersonId) && x.ValidUntil == null)
            .ToList()
            ;

        var addresses = _dbContext
            .Addresses
            .Where(x => x.OperationId == currentOp.Id && x.ValidUntil == null)
            .ToList();

        var studentDetails = _dbContext
            .StudentDetails
            .Where(x => studentIds.Contains(x.StudentId) && x.ValidUntil == null)
            .ToList();

        var output = new List<StudentRecordDetail>();

        var currentYear = now.ToDateTimeUtc().Year;

        var thisYearsFirstSeptember = Instant.FromDateTimeUtc(new DateTime(currentYear, 9, 1, 0, 0, 0, DateTimeKind.Utc));

        foreach (var personDetail in personDetails)
        {
            var student = students.First(x => x.PersonId == personDetail.PersonId);
            var studentDetail = studentDetails.First(x => x.StudentId == student.Id);

            output.Add(new StudentRecordDetail
            {
                BornOn = personDetail.BornOn.ToString(),
                FirstName = personDetail.FirstName,
                Id = personDetail.Id,
                IdentificationCode = personDetail.IdentificationCode,
                LastName = personDetail.LastName,
                PermanentAddress = personDetail.PermanentAddressId != null ? _mapper.ToDetail(addresses.Single(x => x.Id == personDetail.PermanentAddressId)) : null,
                Sex = (int?)personDetail.Sex,
                YearDotClass = $"{(now > thisYearsFirstSeptember ? currentYear - studentDetail.Class!.ClassDetails.Single(x => x.ValidUntil == null).StartAt.Year + 1 : currentYear - studentDetail.Class!.ClassDetails.Single(x => x.ValidUntil == null).StartAt.Year)}.{studentDetail.Class!.ClassDetails.Single(x => x.ValidUntil == null).Name}",
            });
        }

        var orderedOutput = output.OrderBy(x => x.LastName).ThenBy(x => x.YearDotClass);

        return Ok(ApiListResult.From(orderedOutput));
    }
}
