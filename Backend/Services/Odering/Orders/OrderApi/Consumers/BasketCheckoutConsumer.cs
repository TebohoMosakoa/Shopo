using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Order.Application.Features.Commands.CheckoutOrder;

namespace OrderApi.Consumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;

        public BasketCheckoutConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            Console.WriteLine($"NotificationCreated event consumed. Message: {command}");
        }
    }
}