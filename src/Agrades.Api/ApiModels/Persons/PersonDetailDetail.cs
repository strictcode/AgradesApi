using Agrades.Api.ApiModels.Adresses;
using Agrades.Api.Mapper;
using Agrades.Data.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Agrades.Api.ApiModels.Persons;
public class PersonDetailDetail
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("versions")]
    public ICollection<Data.Entities.Persons.PersonDetail> Versions { get; set; } = new HashSet<Data.Entities.Persons.PersonDetail>();

    public int PersonTypeId { get; set; }
    public int MyProperty { get; set; }

    [JsonProperty("statusCategoryId")]
    public int StatusId { get; set; }

    [JsonProperty("sex")]
    public int? Sex { get; set; }

    [JsonProperty("degreesPre")]
    public string? DegreesPre { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; } = null!;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;

    [JsonProperty("degreePost")]
    public string? DegreesPost { get; set; }

    [JsonProperty("birthName")]
    public string? BirthName { get; set; }

    [JsonProperty("bornOn")]
    public string? BornOn { get; set; }

    [JsonProperty("birthAddress")]
    public AddressPerson? BirthAddress { get; set; }

    [JsonProperty("familyStatusId")]
    public int? FamilyStatusId { get; set; }

    [JsonProperty("identityCardNumber")]
    public string? IdentityCardNumber { get; set; }

    [JsonProperty("identificationCode")]
    public string? IdentificationCode { get; set; }

    [JsonProperty("citizenship")]
    public string? Citizenship { get; set; }

    [JsonProperty("citizenshipCode")]
    public string? CitizenshipCode { get; set; }

    [JsonProperty("insuranceCompanyCode")]
    public string? InsuranceCompanyCode { get; set; }

    [JsonProperty("backofficeNote")]
    public string? BackofficeNote { get; set; }

    [JsonProperty("permanentAddress")]
    public AddressPerson? PermanentAddress { get; set; }

    [JsonProperty("temporaryAddress")]
    public AddressPerson? TemporaryAddress { get; set; }

    [JsonProperty("contactAddress")]
    public AddressPerson? ContactAddress { get; set; }

    [JsonProperty("dataBox")]
    public string? DataBox { get; set; }
}

public static class PersonDetailModelExtenstions
{
    public static IQueryable<PersonDetail> IncludeForDetail(this IQueryable<PersonDetail> source)
        => source
        .Include(x => x.BirthAddress)
        .Include(x => x.ContactAddress)
        .Include(x => x.TemporaryAddress)
        .Include(x => x.PermanentAddress)
        .Include(x => x.ContactAddress)
        ;

    public static PersonDetailDetail ToDetail(this IAppMapper mapper, PersonDetail source)
        => new()
        {
            Id = source.Id,
            //StatusId = source.StatusCategoryId,
            Sex = source.Sex,
            DegreesPre = source.DegreesPre,
            DegreesPost = source.DegreesPost,
            FirstName = source.FirstName,
            LastName = source.LastName,
            BirthName = source.BirthName,
            BornOn = source.BornOn?.ToString(),
            BirthAddress = source.BirthAddress != null ? mapper.ToDetail(source.BirthAddress) : null,
            BackofficeNote = source.BackofficeNote,
            IdentificationCode = source.IdentificationCode,
            Citizenship = source.Citizenship,
            CitizenshipCode = source.CitizenshipCode,
            ContactAddress = source.ContactAddress != null ? mapper.ToDetail(source.ContactAddress) : null,
            DataBox = source.DataBox,
            FamilyStatusId = source.FamilyStatusId,
            IdentityCardNumber = source.IdentityCardNumber,
            InsuranceCompanyCode = source.InsuranceCompanyCode,
            PermanentAddress = source.PermanentAddress != null ? mapper.ToDetail(source.PermanentAddress) : null,
            TemporaryAddress = source.TemporaryAddress != null ? mapper.ToDetail(source.TemporaryAddress) : null,
        };
}
