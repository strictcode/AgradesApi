namespace Agrades.Data.Entities;
[Table(nameof(Class))]
public class Class : ITrackable
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public Instant StartAt { get; set; }

    public ICollection<Group> Groups { get; set; } = new HashSet<Group>();

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; } 
}
