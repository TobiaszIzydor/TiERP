using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser;
using TiWms.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiWms.Application.Customer.Commands.CreateCustomer;
using TiWms.Application.Customer.Queries.GetAllCustomers;
using TiWms.Application.Employee.Commands.CreateEmployee;
using TiWms.Application.Employee.Queries.GetAllEmployees;
using TiWms.Application.Mappings;
using TiWms.Application.Order.Commands.CreateOrder;
using TiWms.Application.OrderItem.Commands.AssignToOrder;
using TiWms.Application.OrderItem.Commands.CreateOrderItem;
using TiWms.Application.ProductionItem.Commands.CreateProductionItem;
using TiWms.Application.ProductionItem.Queries.GetProductionItemById;
using TiWms.Application.ProductionItem.Queries.GetProductionItemByIdEntity;
using TiWms.Application.ProductionLine.Commands.CreateProductionLine;
using TiWms.Application.ProductionLine.Queries.GetAllProductionLines;
using TiWms.Domain.Entities;

namespace TiWms.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateProductionLineCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateProductionItemCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(SetRoleToApplicationUserCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(AssignToOrderCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateOrderItemCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetProductionItemByIdQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetProductionItemByIdEntityQuery).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(SomeOtherCommand).Assembly);
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateEmployeeCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
