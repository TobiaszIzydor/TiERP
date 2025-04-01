using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Application.Customer.DTOs;
using TiErp.Application.Customer.Queries.GetCustomerById;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Customer
{
    public class GetCustomerByIdQueryHandlerTests
    {    
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<GetCustomerByIdQuery, CustomerDto> _handler;
        public GetCustomerByIdQueryHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetCustomerByIdQueryHandler
            (
                _customerRepositoryMock.Object,
                _mapperMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Return_Customer_When_Customer_Exists()
        {
            //Arrange
            int id = 1;
            var customer = new Domain.Entities.Customer
            {
                Id = id,
                Name = "Testowa firma",
                Address = "Testowy 1",
                Phone = "112233445",
                CreatedById = "user_id"
            };

            _customerRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync(customer);
            _mapperMock.Setup(x => x.Map<CustomerDto>(It.IsAny<Domain.Entities.Customer>()))
                .Returns((Domain.Entities.Customer c) => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    CreatedById = c.CreatedById,
                });

            var query = new GetCustomerByIdQuery(id);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(customer.Id);
            result.Name.Should().Be(customer.Name);
            result.Phone.Should().Be(customer.Phone);
            result.Address.Should().Be(customer.Address);
            result.CreatedById.Should().Be(customer.CreatedById);

            _customerRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Return_Null_When_Customer_Does_Not_Exist()
        {
            //Arrange
            int id = 1;

            _customerRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync((Domain.Entities.Customer)null);

            var query = new GetCustomerByIdQuery(id);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            result.Should().BeNull();
        }
    }
}
