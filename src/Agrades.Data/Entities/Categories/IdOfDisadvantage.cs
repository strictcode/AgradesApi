using Agrades.Data.Entities.Persons;

namespace Agrades.Data.Entities.Categories;

public class IdOfDisadvantage
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public DisaA? A { get; set; }
    public Razn? Bb { get; set; }
    public Razn? Cc { get; set; }
    public Sz? D { get; set; }
    public DisaE? Ee { get; set; }
    public Razn? Ff { get; set; }
    public Razn? Gg { get; set; }
    public Razn? Hh { get; set; }
}