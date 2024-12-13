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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public OrderItemRepository(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task AssignToOrder(int orderId, int orderItemId)
        {
            var order = await _dbContext.Orders.FirstAsync(o => o.Id == orderId);
            var orderItem = await _dbContext.OrderItems.FirstAsync(o => o.Id == orderItemId);
            order.Items.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }
        public OrderItem GetByIdEntity(int id)
        {
            var orderItem = _dbContext.OrderItems.FirstOrDefault(x => x.Id == id);
            return orderItem;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.OrderItems.Remove(delete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            var orderItems = await _dbContext.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.ProductionLine).ToListAsync();
            return orderItems;
        }

        public async Task<OrderItem> GetById(int id)
        {
            var orderItem = await _dbContext.OrderItems.FirstAsync(x => x.Id == id);
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(int id)
        {
            var order = await _dbContext.Orders.FirstAsync(o =>o.Id == id);
            var orderItems = order.Items.ToList();
            return orderItems;
        }
        public async Task<IEnumerable<OrderItem>> GetForProductionLine(int id)
        {
            var orders = await _dbContext.OrderItems.Include(oi => oi.Product)
                .ThenInclude(p => p.ProductionLine)
                .Where(p => p.Product.ProductionLine.Id == id).ToListAsync();
            return orders;
        }
    }
}
