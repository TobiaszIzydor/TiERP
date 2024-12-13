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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public CustomerRepository(TiWmsDbContext dbContext)
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
        public Customer GetByIdEntity(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.Customers.Remove(delete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
            => await _dbContext.Customers.Include(p => p.CreatedBy).ToListAsync();
        
        public async Task<Customer> GetById(int id)
            => await _dbContext.Customers.Include(p => p.CreatedBy).FirstAsync(x => x.Id == id);

    }
}
