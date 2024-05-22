using AutoMapper;
using Order.Application.Features.Commands.CheckoutOrder;
using Order.Application.Features.Commands.UpdateOrder;
using Order.Application.Features.Queries.GetOrderList;
using Order.Domain.Models;

namespace Order.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOrder, OrdersVm>().ReverseMap();
            CreateMap<UserOrder, CheckoutOrderCommand>().ReverseMap();
            CreateMap<UserOrder, UpdateOrderCommand>().ReverseMap();
        }
    }
}
