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
    public class WarehouseOrderRepository : IWarehouseOrderRepository
    {
        private readonly TiErpDbContext _dbContext;
        public WarehouseOrderRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(WarehouseOrder warehouseOrder)
        {
            _dbContext.WarehouseOrders.Add(warehouseOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var warehouseOrder = await GetById(id);
            if(warehouseOrder != null)
            {
                _dbContext.WarehouseOrders.Remove(warehouseOrder);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WarehouseOrder>> GetAll()
        {
            var warehouseOrders = await _dbContext.WarehouseOrders.Include(wo => wo.Items).ToListAsync();
            return warehouseOrders;
        }

        public async Task<WarehouseOrder> GetById(int id)
        {
            var warehouseOrder = await _dbContext.WarehouseOrders.Include(wo => wo.Items).FirstAsync(wo => wo.Id == id);
            return warehouseOrder;
        }
    }
}
