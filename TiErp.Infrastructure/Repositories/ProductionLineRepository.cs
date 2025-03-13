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
    public class ProductionLineRepository : IProductionLineRepository
    {
        private readonly TiErpDbContext _dbContext;
        public ProductionLineRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(ProductionLine productionLine)
        {
            _dbContext.ProductionLines.Add(productionLine);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.ProductionLines.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductionLine>> GetAll()
            => await _dbContext.ProductionLines.ToListAsync();

        public async Task<ProductionLine> GetById(int id)
            => await _dbContext.ProductionLines.FirstAsync(e => e.Id == id);

        public async Task Update(ProductionLine productionLine)
        {
            var toUpdate = await _dbContext.ProductionLines.FirstAsync(e => e.Id == productionLine.Id);
            toUpdate.LineLiderId = productionLine.LineLiderId;
            toUpdate.Name = productionLine.Name;
            await _dbContext.SaveChangesAsync();
        }
    }
}
