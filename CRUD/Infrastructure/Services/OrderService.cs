using AutoMapper;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBO = Infrastructure.BusinessObjects.Order;
using OrderEO = Infrastructure.Entities.Order;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public void CreateOrder(OrderBO order)
        {
            var orderEO = _mapper.Map<OrderEO>(order);
            _applicationUnitOfWork.Orders.Add(orderEO);
            _applicationUnitOfWork.Save();
        }

        public void UpdateOrder(OrderBO order)
        {
            var orderEO = _applicationUnitOfWork.Orders.GetById(order.Id);
            if (orderEO != null)
            {
                orderEO = _mapper.Map(order, orderEO);
                _applicationUnitOfWork.Save();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public void DeleteOrder(Guid id)
        {
            _applicationUnitOfWork.Orders.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public OrderBO GetOrder(Guid id)
        {
            var orderEO = _applicationUnitOfWork.Orders.Get(x => x.Id.Equals(id), "")
                .FirstOrDefault();
            if (orderEO != null)
            {
                var order = _mapper.Map<OrderBO>(orderEO);
                return order;
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public List<OrderBO> GetAllOrders()
        {
            var orderEOs = _applicationUnitOfWork.Orders.GetAll();
            if (orderEOs.Count > 0)
            {
                var orders = _mapper.Map<List<OrderBO>>(orderEOs);
                return orders;
            }
            else
            {
                throw new Exception("No orders found");
            }
        }
    }

}
