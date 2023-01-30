using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities.Persons;
[Table(nameof(Person))]
public class Person
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    [ConcurrencyCheck]
    public int RowCount { get; set; }

    /// <summary>
    /// If there is account connected to this person, this is its Id
    /// </summary>
    public Guid? UserId { get; set; }

    public PersonType PersonTypeId { get; set; }

    public ICollection<PersonDetail> PersonDetails { get; } = new List<PersonDetail>();

    public Student? Student { get; set; }

    private class Configuration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .Property(x => x.PersonTypeId)
                .HasDefaultValue(PersonType.Student);
        }
    }
}
