using Autofac;
using AutoMapper;
using Infrastructure.Services;

namespace CRUD.API.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public Guid ItemId { get; set; }
        public ItemModel Item { get; set; }
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }

        private IOrderItemService _orderItemService;
        private IMapper _mapper;

        public OrderItemModel()
        {

        }

        public OrderItemModel(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        public void ResolveDependecnies(ILifetimeScope scope)
        {
            _orderItemService = scope.Resolve<IOrderItemService>();
            _mapper = scope.Resolve<IMapper>();
        }
    }
}
