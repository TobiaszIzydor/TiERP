using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;
using TiWms.Domain.Interfaces;
using TiWms.Infrastructure.Persistence;

namespace TiWms.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public OrderRepository(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Order GetByIdEntity(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.Orders.Remove(delete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _dbContext.Orders.Include(o => o.Items).ThenInclude(p => p.Product).Include(o => o.CreatedBy).Include(o => o.Customer).ToListAsync();
            return orders;
        }

        public Task<Order> GetById(int id)
        {
            var order = _dbContext.Orders.Include(o => o.Items).ThenInclude(p => p.Product).Include(o => o.CreatedBy).Include(o => o.Customer).FirstAsync(o => o.Id == id);
            return order;
        }
    }
}
