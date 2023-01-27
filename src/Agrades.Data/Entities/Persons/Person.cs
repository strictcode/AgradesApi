using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities.Persons;
[Table(nameof(Person))]
public class Person
{
    public Guid Id { get; set; }

    [ConcurrencyCheck]
    public int RowCount { get; set; }

    /// <summary>
    /// If there is account connected to this person, this is its Id
    /// </summary>
    public Guid? UserId { get; set; }

    public ICollection<PersonDetail> PersonDetails { get; } = new List<PersonDetail>();

    public Student? Student { get; set; }
}
