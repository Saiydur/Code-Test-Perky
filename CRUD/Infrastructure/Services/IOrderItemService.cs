using Infrastructure.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IOrderItemService
    {
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(Guid id);
        OrderItem GetOrderItem(Guid id);
        List<OrderItem> GetAllOrderItems();
    }
}
