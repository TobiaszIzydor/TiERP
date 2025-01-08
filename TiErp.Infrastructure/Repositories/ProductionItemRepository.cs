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
    public class ProductionItemRepository : IProductionItemRepository
    {
        private readonly TiErpDbContext _dbContext;
        public ProductionItemRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(ProductionItem productionItem)
        {
            _dbContext.ProductionItems.Add(productionItem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.ProductionItems.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductionItem>> GetAll()
        {
            var productionItems = _dbContext.ProductionItems.Include(p => p.Product).Include(p => p.CreatedBy).ToList();
            return productionItems;
        }

        public async Task<IEnumerable<ProductionItem>> GetAllForProduct(int id)
        {
            var productionItems =  await _dbContext.ProductionItems.Include(pi => pi.Product).Include(p => p.CreatedBy).Where(pi => pi.Product.Any(p => p.Id == id)).ToListAsync();
            return productionItems;
        }

        public async Task<ProductionItem> GetById(int id)
        {
            var productionItem = await _dbContext.ProductionItems.Include(p => p.CreatedBy).FirstAsync(p => p.Id == id);
            return productionItem;
        }
        public async Task AssignToProduct(Product product, ProductionItem productionItem)
        {
            productionItem.Product.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
