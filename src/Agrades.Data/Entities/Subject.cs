namespace Agrades.Data.Entities;
[Table(nameof(Subject))]
public class Subject : IOperationFilter
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;
}
