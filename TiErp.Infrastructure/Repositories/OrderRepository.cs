﻿using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly TiErpDbContext _dbContext;
        public OrderRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.Orders.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(Order order)
        {
            order.Id = 0;
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
            var order = _dbContext.Orders.Include(o => o.Items).ThenInclude(p => p.Product).Include(o => o.CreatedBy).Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);
            if(order.Result == null)
            {
                throw new ArgumentException("An order with this ID does not exist.");
            }
            return order;
        }

        public async Task<int> GetCountOrderOrderedInMonth()
        {
            int count = await _dbContext.Orders.Where(o => o.OrderedAt.Month == DateTime.UtcNow.Month).CountAsync();
            return count;
        }
    }
}
