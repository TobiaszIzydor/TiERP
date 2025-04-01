using AutoMapper;
using Castle.Core.Resource;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;
using TiErp.Application.Customer.Queries.GetAllCustomers;
using TiErp.Application.Customer.Queries.GetCustomerById;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Customer
{
    public class GetAllCustomersQueryHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>> _handler;
        public GetAllCustomersQueryHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllCustomersQueryHandler
            (
                _customerRepositoryMock.Object,
                _mapperMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Return_All_Customers()
        {
            //Arrange
            var customers = new List<Domain.Entities.Customer>
            {
                new Domain.Entities.Customer
                {
                    Id = 1,
                    Name = "Testowa firma",
                    Address = "Testowy 1",
                    Phone = "112233445",
                    CreatedById = "user_id"
                },
                new Domain.Entities.Customer
                {
                    Id = 2,
                    Name = "Prawdziwa firma",
                    Address = "Przykładowa 2",
                    Phone = "123456789",
                    CreatedById = "user2_id"
                }
            };
            
            _customerRepositoryMock.Setup(x => x.GetAll())
                .ReturnsAsync( customers );
            _mapperMock.Setup(x => x.Map<IEnumerable<CustomerDto>>(It.IsAny<IEnumerable<Domain.Entities.Customer>>()))
                .Returns(customers.Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    CreatedById = c.CreatedById,
                }).ToList());

            var query = new GetAllCustomersQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert

            result.Should().NotBeNull();

            var firstCustomer = result.First();
            firstCustomer.Id.Should().Be(customers[0].Id);
            firstCustomer.Name.Should().Be(customers[0].Name);
            firstCustomer.Phone.Should().Be(customers[0].Phone);
            firstCustomer.Address.Should().Be(customers[0].Address);
            firstCustomer.CreatedById.Should().Be(customers[0].CreatedById);

            var secondCustomer = result.Last();
            secondCustomer.Id.Should().Be(customers[1].Id);
            secondCustomer.Name.Should().Be(customers[1].Name);
            secondCustomer.Phone.Should().Be(customers[1].Phone);
            secondCustomer.Address.Should().Be(customers[1].Address);
            secondCustomer.CreatedById.Should().Be(customers[1].CreatedById);
        }
    }
}
