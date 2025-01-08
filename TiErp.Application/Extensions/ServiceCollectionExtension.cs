using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser;
using TiErp.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiErp.Application.Customer.Commands.CreateCustomer;
using TiErp.Application.Customer.Queries.GetAllCustomers;
using TiErp.Application.Employee.Commands.CreateEmployee;
using TiErp.Application.Employee.Queries.GetAllEmployees;
using TiErp.Application.Mappings;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.Application.OrderItem.Commands.AssignToOrder;
using TiErp.Application.OrderItem.Commands.CreateOrderItem;
using TiErp.Application.ProductionItem.Commands.CreateProductionItem;
using TiErp.Application.ProductionItem.Queries.GetProductionItemById;
using TiErp.Application.ProductionItem.Queries.GetProductionItemByIdEntity;
using TiErp.Application.ProductionLine.Commands.CreateProductionLine;
using TiErp.Application.ProductionLine.Queries.GetAllProductionLines;
using TiErp.Domain.Entities;

namespace TiErp.Application.Extensions
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
