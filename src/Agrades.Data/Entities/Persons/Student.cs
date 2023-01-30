using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities.Persons;
[Table(nameof(Student))]
public class Student
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    [ConcurrencyCheck]
    public int RowCount { get; set; }

    public ICollection<StudentDetail> StudentDetails { get; } = new HashSet<StudentDetail>();

    public ICollection<StudentGroup> Groups { get; set; } = new HashSet<StudentGroup>();

    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;
}
