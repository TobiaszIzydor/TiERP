using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser.DTOs;
using TiWms.Application.Customer.Commands.CreateCustomer;
using TiWms.Application.Customer.Commands.EditCustomer;
using TiWms.Application.Customer.DTOs;
using TiWms.Application.Employee.Commands.EditEmployee;
using TiWms.Application.Employee.DTOs;
using TiWms.Application.Order.Commands.CreateOrder;
using TiWms.Application.Order.Commands.EditOrder;
using TiWms.Application.Order.DTOs;
using TiWms.Application.OrderItem.Commands.CreateOrderItem;
using TiWms.Application.OrderItem.Commands.EditOrderItem;
using TiWms.Application.OrderItem.DTOs;
using TiWms.Application.Product.Commands.EditProduct;
using TiWms.Application.Product.DTOs;
using TiWms.Application.ProductionItem.Commands.CreateProductionItem;
using TiWms.Application.ProductionItem.Commands.EditProductionItem;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Application.ProductionItem.Queries.GetProductionItemById;
using TiWms.Application.ProductionLine.Commands.EditProductionLine;
using TiWms.Application.ProductionLine.DTOs;
using TiWms.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TiWms.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Domain.Entities.Customer>();
            CreateMap<EmployeeDto, Domain.Entities.Employee>().ForMember(e => e.ContactInfo, opt => opt.MapFrom(src => new EmployeeContactInfo()
            {
                Email = src.Email,
                Phone = src.Phone,
                EmergencyPhone = src.EmergencyPhone,
            }));
            CreateMap<Domain.Entities.Employee, EmployeeDto>()
                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.ContactInfo.Email))
                .ForMember(dto => dto.Phone, opt => opt.MapFrom(src => src.ContactInfo.Phone))
                .ForMember(dto => dto.EmergencyPhone, opt => opt.MapFrom(src => src.ContactInfo.EmergencyPhone));
            CreateMap<Domain.Entities.ProductionLine, ProductionLineDto>();
            CreateMap<ProductionLineDto, Domain.Entities.ProductionLine>();
            CreateMap<Domain.Entities.ApplicationUser, ApplicationUserDto>();
            CreateMap<IdentityRole, IdentityRoleDto>();
            CreateMap<ProductionLineDto, EditProductionLineCommand>();
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<ProductDto, Domain.Entities.Product>();
            CreateMap<Domain.Entities.ProductionItem, ProductionItemDto>();
            CreateMap<ProductionItemDto, Domain.Entities.ProductionItem>();
            CreateMap<CreateProductionItemCommand, Domain.Entities.ProductionItem>();
            CreateMap<CreateOrderItemCommand, Domain.Entities.OrderItem>();
            CreateMap<CreateOrderCommand, Domain.Entities.Order>();
            CreateMap<OrderDto, Domain.Entities.Order>();
            CreateMap<OrderItemDto, Domain.Entities.OrderItem>();
            CreateMap<Domain.Entities.OrderItem, OrderItemDto>();
            CreateMap<Domain.Entities.Order, OrderDto>();
            CreateMap<Domain.Entities.Customer, CustomerDto>();
            CreateMap<CustomerDto, Domain.Entities.Customer>();
            CreateMap<CreateCustomerCommand, Domain.Entities.Customer>();
            CreateMap<EditProductionLineCommand, ProductionLineDto>().ReverseMap();
            CreateMap<EditCustomerCommand, CustomerDto>().ReverseMap();
            CreateMap<EditEmployeeCommand, EmployeeDto>().ReverseMap();
            CreateMap<EditProductCommand, ProductDto>().ReverseMap();
            CreateMap<EditProductionItemCommand, ProductionItemDto>().ReverseMap();
            CreateMap<EditOrderCommand, OrderDto>().ReverseMap();
            CreateMap<EditOrderItemCommand, OrderItemDto>().ReverseMap();


        }
    }
}
