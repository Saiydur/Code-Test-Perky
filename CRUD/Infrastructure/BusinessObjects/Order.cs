using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessObjects
{
    public class Order
    {
        public Guid Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public float TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippingDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
