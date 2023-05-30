using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBO = Infrastructure.BusinessObjects.Item;
using ItemEO = Infrastructure.Entities.Item;
using OrderBO = Infrastructure.BusinessObjects.Order;
using OrderEO = Infrastructure.Entities.Order;
using OrderItemBO = Infrastructure.BusinessObjects.OrderItem;
using OrderItemEO = Infrastructure.Entities.OrderItem;

namespace Infrastructure.Profiles
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<ItemEO, ItemBO>().ReverseMap();
            CreateMap<OrderEO, OrderBO>().ReverseMap();
            CreateMap<OrderItemEO, OrderItemBO>().ReverseMap();
        }
    }
}
