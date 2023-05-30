using Autofac;
using AutoMapper;
using Infrastructure.Services;

namespace CRUD.API.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public float TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippingDate { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }

        private IOrderService _orderService;
        private IMapper _mapper;

        public OrderModel()
        {

        }

        public OrderModel(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public void ResolveDependecnies(ILifetimeScope scope)
        {
            _orderService = scope.Resolve<IOrderService>();
            _mapper = scope.Resolve<IMapper>();
        }
    }
}
