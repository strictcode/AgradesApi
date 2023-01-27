namespace Agrades.Data.Entities;
[Table(nameof(Group))]
public class Group : ITrackable
{
    public Guid Id { get; set; }

    public Guid ClassId { get; set; }
    public Class Class { get; set; } = null!;

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public Guid EducationFieldId { get; set; }
    public StudyField EducationField { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? BackofficeName { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
