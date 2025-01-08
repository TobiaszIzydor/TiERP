using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser.DTOs;
using TiErp.Application.Customer.Commands.CreateCustomer;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Application.Customer.DTOs;
using TiErp.Application.Employee.Commands.EditEmployee;
using TiErp.Application.Employee.DTOs;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.Application.Order.Commands.EditOrder;
using TiErp.Application.Order.DTOs;
using TiErp.Application.OrderItem.Commands.CreateOrderItem;
using TiErp.Application.OrderItem.Commands.EditOrderItem;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Application.Product.Commands.EditProduct;
using TiErp.Application.Product.DTOs;
using TiErp.Application.ProductionItem.Commands.CreateProductionItem;
using TiErp.Application.ProductionItem.Commands.EditProductionItem;
using TiErp.Application.ProductionItem.DTOs;
using TiErp.Application.ProductionItem.Queries.GetProductionItemById;
using TiErp.Application.ProductionLine.Commands.EditProductionLine;
using TiErp.Application.ProductionLine.DTOs;
using TiErp.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TiErp.Application.Mappings
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
