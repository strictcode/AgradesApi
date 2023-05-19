using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrades.Data.Entities.Classes;

public class GroupClassType
{
    public Guid Id { get; set; }
    public TypTr? ClassAssistents { get; set; }
    public Tt? ClassTypeDesignation { get; set; }
}