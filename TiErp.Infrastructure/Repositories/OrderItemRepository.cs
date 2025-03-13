using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using TiErp.Infrastructure.Persistence;

namespace TiErp.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TiErpDbContext _dbContext;
        public OrderItemRepository(TiErpDbContext dbContext)
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
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.OrderItems.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            var orderItems = await _dbContext.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.ProductionLine).ToListAsync();
            return orderItems;
        }

        public async Task<OrderItem> GetById(int id)
        {
            var orderItem = await _dbContext.OrderItems.Include(oi => oi.Product).FirstAsync(x => x.Id == id);
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

        public async Task<int> GetCountOrderItemsForProductionLine(ProductionLine productionLine)
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Product).Where(p => p.Product.ProductionLine == productionLine).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsCompletedForProductionLine(ProductionLine productionLine)
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Product).Where(oi => oi.Product.ProductionLine == productionLine).Where(oi => oi.Status == Status.Done).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsForProductionLineInMonth(ProductionLine productionLine)
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Product).Include(oi => oi.Order).Where(oi => oi.Order.DeadLine.Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsCompletedForProductionLineInMonth(ProductionLine productionLine)
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Product).Include(oi => oi.Order).Where(oi => oi.Product.ProductionLine == productionLine).Where(oi => oi.Status == Status.Done).Where(oi => DateOnly.FromDateTime((DateTime)oi.CompletedAt).Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrdersOverduedForProductionLineTotal(ProductionLine productionLine)
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Product).Include(oi => oi.Order).Where(oi => oi.Product.ProductionLine == productionLine).Where(oi => oi.Status != Status.Done).Where(oi => oi.Order.DeadLine < DateOnly.FromDateTime(DateTime.UtcNow)).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsInMonth()
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Order).Where(oi => oi.Order.DeadLine.Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsCompletedInMonth()
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Order).Where(oi => oi.Status == Status.Done).Where(oi => DateOnly.FromDateTime((DateTime)oi.CompletedAt).Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsCompleted()
        {
            int count = await _dbContext.OrderItems.Where(oi => oi.Status == Status.Done).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItems()
        {
            int count = await _dbContext.OrderItems.CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsOverdued()
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Order).Where(oi => oi.Status != Status.Done).Where(oi => oi.Order.DeadLine < DateOnly.FromDateTime(DateTime.UtcNow)).CountAsync();
            return count;
        }

        public async Task<int> GetCountOrderItemsOrderedInMonth()
        {
            int count = await _dbContext.OrderItems.Include(oi => oi.Order).Where(oi => oi.Order.OrderedAt.Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }
    }
}
