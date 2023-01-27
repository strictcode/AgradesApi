namespace Agrades.Data.Entities.Persons;
[Table(nameof(PersonDetail))]
public class PersonDetail : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public PersonType PersonTypeId { get; set; }

    /// <summary>
    /// Draft, Active, Inactive Status Id category (graduated, expelled, transfered, deceased)
    /// </summary>
    public PersonStatus StatusId { get; set; }

    public InactivityReason? InactivityReasonId { get; set; }

    public string? OrganizationUniqueCode { get; set; }

    public int? Sex { get; set; }

    public string? DegreesPre { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? DegreesPost { get; set; }

    public string? BirthName { get; set; }

    public Instant? BornOn { get; set; }

    public int? FamilyStatusId { get; set; }

    public UniqueCodeType? IdentityCardNumberTypeId { get; set; }
    public string? IdentityCardNumber { get; set; }

    public UniqueCodeType? IdentificationCodeTypeId { get; set; }
    public string? IdentificationCode { get; set; }

    public string? Citizenship { get; set; }

    public string? CitizenshipCode { get; set; }

    public string? InsuranceCompanyCode { get; set; }

    public string? DataBox { get; set; }

    public string? BackofficeNote { get; set; }

    public Guid? BirthAddressId { get; set; }
    public Address? BirthAddress { get; set; }

    public Guid PermanentAddressId { get; set; }
    public Address? PermanentAddress { get; set; }

    public Guid TemporaryAddressId { get; set; }
    public Address? TemporaryAddress { get; set; }

    public Guid ContactAddressId { get; set; }
    public Address? ContactAddress { get; set; }

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
