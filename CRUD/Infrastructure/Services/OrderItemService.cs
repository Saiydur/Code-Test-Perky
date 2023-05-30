using AutoMapper;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderItemBO = Infrastructure.BusinessObjects.OrderItem;
using OrderItemEO = Infrastructure.Entities.OrderItem;

namespace Infrastructure.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public OrderItemService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public void CreateOrderItem(OrderItemBO orderItem)
        {
            var orderItemEO = _mapper.Map<OrderItemEO>(orderItem);
            _applicationUnitOfWork.OrderItems.Add(orderItemEO);
            _applicationUnitOfWork.Save();
        }

        public void DeleteOrderItem(Guid id)
        {
            _applicationUnitOfWork.OrderItems.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public List<OrderItemBO> GetAllOrderItems()
        {
            var orderItemEOs = _applicationUnitOfWork.OrderItems.GetAll();
            if (orderItemEOs.Count > 0)
            {
                var orderItemBOs = new List<OrderItemBO>();
                foreach (var orderItemEO in orderItemEOs)
                {
                    var orderItemBO = _mapper.Map<OrderItemBO>(orderItemEO);
                    orderItemBOs.Add(orderItemBO);
                }
                return orderItemBOs;
            }
            else
            {
                throw new Exception("No order items found");
            }
        }

        public OrderItemBO GetOrderItem(Guid id)
        {
            var orderItemEO = _applicationUnitOfWork.OrderItems.Get(x => x.Id.Equals(id), "")
                .FirstOrDefault();
            if (orderItemEO != null)
            {
                var orderItemBO = _mapper.Map<OrderItemBO>(orderItemEO);
                return orderItemBO;
            }
            else
            {
                throw new Exception("Order item not found");
            }
        }

        public void UpdateOrderItem(OrderItemBO orderItem)
        {
            var orderItemEO = _applicationUnitOfWork.OrderItems.GetById(orderItem.Id);
            if (orderItemEO != null)
            {
                orderItemEO = _mapper.Map(orderItem, orderItemEO);
                _applicationUnitOfWork.Save();
            }
            else
            {
                throw new Exception("Order item not found");
            }
        }
    }
}
