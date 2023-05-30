using AutoMapper;
using CRUD.API.Models;
using Infrastructure.BusinessObjects;

namespace CRUD.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Item,ItemModel>().ReverseMap();
            CreateMap<Order,OrderModel>().ReverseMap();
            CreateMap<OrderItem,OrderItemModel>().ReverseMap();
        }
    }
}
