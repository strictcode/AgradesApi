namespace Agrades.Data.Entities;
[Table(nameof(Organization))]
public class Organization : ITrackable
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string RedIzo { get; set; } = null!;

    /// <summary>
    /// Izo
    /// </summary>
    public string? IdentificationCode { get; set; }
    public UniqueCodeType IdentificationCodeTypeId { get; set; }

    public bool IsSingleOperationOrg { get; set; }

    public ICollection<Operation> Operations = new HashSet<Operation>();

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
