using AutoMapper;
using BasketApi.Models;
using EventBus.Messages.Events;

namespace BasketApi.Mappings
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
