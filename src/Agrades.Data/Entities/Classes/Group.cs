namespace Agrades.Data.Entities.Classes;
[Table(nameof(Group))]
public class Group : ITrackable, IVersionable, IOperationFilter
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

    //TT    B-běžná , Z - podle vyhlášky
    public Tt? ClassTypeDesignation { get; set; }

    //TYP_TR
    public Guid GroupClassTypeId { get; set; }
    public GroupClassType? GroupClassType { get; set; }

    public ICollection<StudentGroup> Students { get; set; } = new HashSet<StudentGroup>();

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
