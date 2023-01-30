using Agrades.Api.ApiModels.Adresses;
using Agrades.Api.ApiModels.Persons;
using Agrades.Api.Mapper;
using Agrades.Api.Utilities;
using Agrades.Data;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Categories;
using Agrades.Data.Entities.Persons;
using Agrades.Data.Interfaces;
using Agrades.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

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

    [HttpPost("/api/v1/{opUrlName}/ImportStudents")]
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
        var lines = model.Data.ToList(); //data.Split(Environment.NewLine);
        var classes = _dbContext.Classes.Include(x => x.Groups);

        // skip table header
        for (int i = 1; i < lines.Count; i++)
        {
            // KOMPLET vytvářet Studenta a Usera tady. Předělat migraci OperationId do horních entit. Resetovat migrace na init
            // ověřit volání Local
            var values = lines[i].Split(';');

            //var personId = Guid.Parse(values[0].ToLower());
            //var studId = Guid.Parse(values[1].ToLower());

            var birthDate = new DateTime(int.Parse(values[10].Split('.')[2]), int.Parse(values[10].Split('.')[1]), int.Parse(values[10].Split('.')[0]), 0,0,0, DateTimeKind.Utc);

            var startsAt = Instant.FromDateTimeUtc(new DateTime(int.Parse(values[50].Split('.')[2]), int.Parse(values[50].Split('.')[1]), int.Parse(values[50].Split('.')[0]), 0, 0, 0, DateTimeKind.Utc));

            var personDetail = new PersonDetail
            {
                //Id = Guid.Parse(values[2].ToLower()),
                OperationId = currentOp!.Id,
                OrganizationUniqueCode = values[0],
                LastName = values[1],
                FirstName = values[2],
                InsuranceCompanyCode = values[7],
                IdentificationCode = values[8],
                IdentificationCodeTypeId = UniqueCodeType.BirthNumber,
                Sex = values[9] == "Muž" ? Sex.Male : Sex.Female,
                BornOn = Instant.FromDateTimeUtc(birthDate),
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
                State = values[12],
                ValidSince = startsAt,
            }.SetCreateBySystem(now);

            _dbContext.Add(permAddress);

            personDetail.PermanentAddress = permAddress;

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
                //Id = Guid.Parse(values[3].ToLower()),
                StartsAt = startsAt,
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
            var currentClass = classes.Single(x => x.Name.ToLower() == c.ToLower());

            studentDetail.ClassId = currentClass.Id;
            currentClass.Groups.First().Students.Add(new StudentGroup
            {
                StudentId = student.Id,
                ValidSince = now,
            }.SetCreateBySystem(now));

            Print(values);
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
            .Include(x => x.Student)
            .Where(x => x.PersonTypeId == PersonType.Student && x.OperationId == currentOp!.Id)
            .Select(x => x.Id)
            .ToList();

        var students = _dbContext
            .Students
            .Include(x => x.Groups)
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
            .Include(x => x.Class)
            .Where(x => studentIds.Contains(x.StudentId) && x.ValidUntil == null)
            .ToList();

        var output = new List<StudentRecordDetail>();

        var currentYear = now.ToDateTimeUtc().Year;

        var thisYearsFirstSeptember = Instant.FromDateTimeUtc(new DateTime(currentYear, 9, 1, 0, 0 , 0, DateTimeKind.Utc));

        foreach (var personDetail in personDetails)
        {
            var student = students.First(x => x.PersonId == personDetail.PersonId);
            var studentDetail = studentDetails.First(x => x.StudentId == student.Id);

            output.Add(new StudentRecordDetail
            {
                //BackofficeNote = personDetail.BackofficeNote,
                //BirthAddress = personDetail.BirthAddressId != null ? _mapper.ToDetail(addresses.Single(x => x.Id == personDetail.BirthAddressId)) : null,
                //DegreesPost = personDetail.DegreesPost,
                //DegreesPre = personDetail.DegreesPre,
                //BirthName = personDetail.BirthName,
                BornOn = personDetail.BornOn.ToString(),
                //Citizenship = personDetail.Citizenship,
                //CitizenshipCode = personDetail.CitizenshipCode,
                //ContactAddress = personDetail.ContactAddressId != null ? _mapper.ToDetail(addresses.Single(x => x.Id == personDetail.ContactAddressId)) : null,
                //DataBox = personDetail.DataBox,
                //FamilyStatusId = personDetail.FamilyStatusId,
                FirstName = personDetail.FirstName,
                Id = personDetail.Id,
                IdentificationCode = personDetail.IdentificationCode,
                //IdentityCardNumber = personDetail.IdentityCardNumber,
                //InsuranceCompanyCode = personDetail.InsuranceCompanyCode,
                LastName = personDetail.LastName,
                PermanentAddress = personDetail.PermanentAddressId != null ? _mapper.ToDetail(addresses.Single(x => x.Id == personDetail.PermanentAddressId)) : null,
                //PersonTypeId = (int)PersonType.Student,
                Sex = (int?)personDetail.Sex,
                //TemporaryAddress = personDetail.TemporaryAddressId != null ? _mapper.ToDetail(addresses.Single(x => x.Id == personDetail.TemporaryAddressId)) : null,
                YearDotClass = $"{(now > thisYearsFirstSeptember ? currentYear - studentDetail.Class!.StartAt.ToDateTimeUtc().Year + 2 : currentYear - studentDetail.Class!.StartAt.ToDateTimeUtc().Year + 1)}.{studentDetail.Class!.Name}",
            });
        }

        var orderedOutput = output.OrderBy(x => x.LastName).ThenBy(x => x.YearDotClass);

        return Ok(ApiListResult.From(orderedOutput));
    }
}
