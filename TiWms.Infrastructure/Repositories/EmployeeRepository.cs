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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public EmployeeRepository(TiWmsDbContext dbContext)
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
        public Employee GetByIdEntity(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }
        public async Task DeleteById(int id)
        {
            var delete = GetByIdEntity(id);
            _dbContext.Employees.Remove(delete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetAll()
            => await _dbContext.Employees.Include(e => e.User).ToListAsync();

        public async Task<Employee> GetById(int employeeId)
            => await _dbContext.Employees.Include(e => e.User).FirstAsync(e => e.Id == employeeId);

        public async Task<IEnumerable<Employee>> GetLiders()
            => await _dbContext.Employees.Where(e => e.User != null && _dbContext.UserRoles.Any(ur => ur.UserId == e.User.Id && ur.RoleId == _dbContext.Roles.Where(r => r.Name == "Lider").Select(r => r.Id).FirstOrDefault())).ToListAsync();
    }
}
