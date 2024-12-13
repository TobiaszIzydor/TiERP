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
    public class ProductionItemRepository : IProductionItemRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public ProductionItemRepository(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(ProductionItem productionItem)
        {
            _dbContext.ProductionItems.Add(productionItem);
            await _dbContext.SaveChangesAsync();
        }
        public ProductionItem GetByIdEntity(int id)
        {
            var productionItem = _dbContext.ProductionItems.FirstOrDefault(x => x.Id == id);
            return productionItem;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.ProductionItems.Remove(delete);
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
