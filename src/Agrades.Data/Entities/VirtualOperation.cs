namespace Agrades.Data.Entities;
[Table(nameof(VirtualOperation))]
public class VirtualOperation : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Izo
    /// </summary>
    public string IdentificationCode { get; set; } = null!;
    public UniqueCodeType IdentificationCodeTypeId { get; set; }

    public Rapz SchoolType { get; set; }

    public Guid? OperationId { get; set; }
    public Operation? Operation { get; set; }

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
