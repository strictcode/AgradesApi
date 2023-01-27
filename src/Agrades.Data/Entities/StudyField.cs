namespace Agrades.Data.Entities;
[Table(nameof(StudyField))]
public class StudyField : ITrackable
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Qualifier { get; set; } = null!;

    public string? BackofficeName { get; set; }

    public Language Language { get; set; }

    public FieldOfStudyType Type { get; set; }

    public int LengthInYears { get; set; }

    public int Form { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
