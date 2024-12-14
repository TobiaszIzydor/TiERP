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
    public class ProductRepository : IProductRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public ProductRepository(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        public Product GetByIdEntity(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.Products.Remove(delete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products =  _dbContext.Products.Include(p => p.ProductionLine).Include(p => p.ProductionItems).Include(p => p.CreatedBy).ToList();
            return products;
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _dbContext.Products.Include(p => p.ProductionLine).Include(p => p.ProductionItems).Include(p => p.CreatedBy).FirstAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllSimply()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }
    }
}
