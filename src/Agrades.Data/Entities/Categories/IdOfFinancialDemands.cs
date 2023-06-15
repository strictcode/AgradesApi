using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrades.Data.Entities.Categories;

public class IdOfFinancialDemands
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public FinA A { get; set; }
    public string? B { get; set; }
    public string? Cccc { get; set; }
    public FinD D { get; set; }
    public string Ee { get; set; }
} 