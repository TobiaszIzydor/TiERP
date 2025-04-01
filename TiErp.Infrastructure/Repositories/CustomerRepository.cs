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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TiErpDbContext _dbContext;
        public CustomerRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.Customers.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
            => await _dbContext.Customers.Include(p => p.CreatedBy).ToListAsync();
        
        public async Task<Customer> GetById(int id)
            => await _dbContext.Customers.Include(p => p.CreatedBy)
            .Include(c => c.Orders).FirstAsync(x => x.Id == id);

    }
}
