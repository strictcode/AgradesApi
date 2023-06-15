using Agrades.Data.Entities.Persons;

namespace Agrades.Data.Entities.Classes;
[Table(nameof(StudentGroup))]
public class StudentGroup : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
