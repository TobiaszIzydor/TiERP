using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Interfaces;
using TiWms.Infrastructure.Persistence;
using TiWms.Infrastructure.Seeders;
using TiWms.Infrastructure.Seeders.Repositories;

namespace TiWms.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TiWmsDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("TiWms")));
            services.AddScoped<EmployeeSeeder>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
