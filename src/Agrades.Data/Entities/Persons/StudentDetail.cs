namespace Agrades.Data.Entities.Persons;
[Table(nameof(StudentDetail))]
public class StudentDetail : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public Guid? ClassId { get; set; }
    public Class? Class { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public Instant StartsAt { get; set; }

    public string? StartReasonCode { get; set; }

    public int? ObligatoryAttendenceYears { get; set; }

    public int? Financing { get; set; }

    public Instant? EndsAt { get; set; }

    public string? EndReasonCode { get; set; }

    public Guid StudyFieldId { get; set; }
    public StudyField StudyField { get; set; } = null!;

    public bool? IsOnInternat { get; set; }

    public bool? HasSchoolMeals { get; set; }

    public FieldOfStudyType HighestAchievedEducation { get; set; }

    public string? PreviousEducationCode { get; set; }

    public Guid? PreviousEducationOperationId { get; set; }
    public VirtualOperation? PreviousEducationOperation { get; set; } = null!;

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
