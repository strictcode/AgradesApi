using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrades.Data.Entities.Categories
{
    public class Rast
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =null!;
        public string Code { get; set; } = null!;
        public HashSet<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
