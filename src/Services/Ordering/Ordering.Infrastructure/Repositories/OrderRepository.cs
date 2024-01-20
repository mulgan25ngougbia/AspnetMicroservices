using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contrats.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrderByUsername(string username)
        {
            var orderList = await _dbContext.Orders
                                   .Where(o => o.UserName == username)
                                   .ToListAsync();
            return orderList;
        }

    }
}
