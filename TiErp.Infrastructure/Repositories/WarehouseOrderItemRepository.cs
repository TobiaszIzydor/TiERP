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
    public class WarehouseOrderItemRepository : IWarehouseOrderItemRepository
    {
        private readonly TiErpDbContext _dbContext;
        public WarehouseOrderItemRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task Create(WarehouseOrderItem warehouseOrderItem)
        {
            _dbContext.WarehouseOrdersItems.Add(warehouseOrderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WarehouseOrderItem>> GetAll()
        {
            var warehouseOrderItems = await _dbContext.WarehouseOrdersItems.ToListAsync();
            return warehouseOrderItems;
        }

        public async Task<WarehouseOrderItem> GetById(int id)
        {
            var warehouseOrderItem = await _dbContext.WarehouseOrdersItems.FirstAsync(woi => woi.Id == id);
            return warehouseOrderItem;
        }
    }
}
