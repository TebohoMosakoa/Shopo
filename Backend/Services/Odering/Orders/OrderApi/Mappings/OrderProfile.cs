using AutoMapper;
using EventBus.Messages.Events;
using Order.Application.Features.Commands.CheckoutOrder;

namespace OrderApi.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
