using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CRUD.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderInvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime? ShippingDate { get; set; }
        public float TotalPrice { get; set; }

        public Order()
        {
            OrderDateTime = DateTime.Now;
        }
    }
}
