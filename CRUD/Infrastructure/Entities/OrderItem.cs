using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class OrderItem : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
