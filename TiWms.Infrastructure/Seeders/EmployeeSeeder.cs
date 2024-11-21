using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;
using TiWms.Infrastructure.Persistence;

namespace TiWms.Infrastructure.Seeders
{
    public class EmployeeSeeder
    {
        private readonly TiWmsDbContext _dbContext;

        public EmployeeSeeder(TiWmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Employees.Any())
                {
                    var tobiaszI = new Employee()
                    {
                        FirstName = "Tobiasz",
                        LastName = "Izydor",
                        HireDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        ContactInfo = new()
                        {
                            Email = "tobiasz.izydor02@gmail.com",
                            Phone = "+48111222333",
                            EmergencyPhone = "+48123123123",
                        }
                    };
                    _dbContext.Employees.Add(tobiaszI);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
