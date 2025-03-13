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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TiErpDbContext _dbContext;
        public EmployeeRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            var delete = await GetById(id);
            if (delete != null)
            {
                _dbContext.Employees.Remove(delete);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetAll()
            => await _dbContext.Employees.Include(e => e.User).ToListAsync();

        public async Task<Employee> GetById(int employeeId)
            => await _dbContext.Employees.Include(e => e.User).Include(e => e.ProductionLine).ThenInclude(pl => pl.LineLider).FirstAsync(e => e.Id == employeeId);

        public async Task<int> GetCountAllEmployees()
            => await _dbContext.Employees.CountAsync();
        public async Task<IEnumerable<Employee>> GetLiders()
            => await _dbContext.Employees.Where(e => e.User != null && _dbContext.UserRoles.Any(ur => ur.UserId == e.User.Id && ur.RoleId == _dbContext.Roles.Where(r => r.Name == "Lider").Select(r => r.Id).FirstOrDefault())).ToListAsync();
    }
}
