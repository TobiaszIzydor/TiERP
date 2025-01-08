using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using TiErp.Infrastructure.Persistence;
using TiErp.Infrastructure.Repositories;
using TiErp.Infrastructure.Seeders;

namespace TiErp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TiErpDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("TiErp")));
/*            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TiErpDbContext>();*/
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TiErpDbContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductionLineRepository, ProductionLineRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductionItemRepository, ProductionItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        }
    }
}
