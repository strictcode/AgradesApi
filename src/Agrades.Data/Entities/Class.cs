using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities;
[Table(nameof(Class))]
public class Class
{
    public Guid Id { get; set; }

    [ConcurrencyCheck]
    public int RowCount { get; set; }

    public ICollection<ClassDetail> ClassDetails { get; set; } = new HashSet<ClassDetail>();

    public ICollection<Group> Groups { get; set; } = new HashSet<Group>();

}
