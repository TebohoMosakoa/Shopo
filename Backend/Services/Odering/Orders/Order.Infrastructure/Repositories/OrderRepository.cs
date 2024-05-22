using Microsoft.EntityFrameworkCore;
using Order.Application.Contracts;
using Order.Domain.Models;
using Order.Infrastructure.Persistence;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<UserOrder>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<UserOrder>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}
