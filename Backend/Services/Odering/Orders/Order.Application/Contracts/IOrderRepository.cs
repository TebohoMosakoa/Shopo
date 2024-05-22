using Order.Domain.Models;

namespace Order.Application.Contracts
{
    public interface IOrderRepository : IAsyncRepository<UserOrder>
    {
        Task<IEnumerable<UserOrder>> GetOrdersByUserName(string userName);
    }
}
