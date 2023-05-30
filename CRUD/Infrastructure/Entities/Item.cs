using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Item : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
