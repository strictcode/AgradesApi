namespace Agrades.Data.Entities;
[Table(nameof(Category))]
public class Category : ITrackable, IOperationFilter
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int Order { get; set; }

    public int CategoryTypeId { get; set; }
    public CategoryType CategoryType { get; set; }

    public Guid UniqueStamp { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
