using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities.Persons;
[Table(nameof(Student))]
public class Student
{
    public Guid Id { get; set; }

    [ConcurrencyCheck]
    public int RowCount { get; set; }

    public ICollection<PersonDetail> StudentDetails { get; } = new List<PersonDetail>();

    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;
}
