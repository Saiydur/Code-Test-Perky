using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string InvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public float TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippingDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
