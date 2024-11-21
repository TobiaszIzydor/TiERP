using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;
using TiWms.Domain.Interfaces;
using TiWms.Infrastructure.Persistence;

namespace TiWms.Infrastructure.Seeders.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public EmployeeRepository(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
