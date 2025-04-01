using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser;
using TiErp.Application.Customer.Commands.DeleteCustomer;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TiErp.Tests.Application.Customer
{
    public class DeleteCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly IRequestHandler<DeleteCustomerCommand, Unit> _handler;
        public DeleteCustomerCommandHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _handler = new DeleteCustomerCommandHandler
            (
                _customerRepositoryMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Delete_Customer_When_Customer_Exists()
        {
            //Arrange
            var existingCustomer = new Domain.Entities.Customer
            {
                Id = 1,
                Name = "Test",
                Address = "Testowa 1, Poznan",
                Phone = "111222333",
            };
            _customerRepositoryMock.Setup(x => x.DeleteById(1))
                .Returns(Task.CompletedTask);
            _customerRepositoryMock.Setup(x => x.GetById(1))
                .ReturnsAsync(existingCustomer);

            var command = new DeleteCustomerCommand(existingCustomer.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Customer_Does_Not_Exist()
        {
            var id = 1;
            _customerRepositoryMock.Setup(x => x.GetById(1))
                .ReturnsAsync((Domain.Entities.Customer)null);

            var command = new DeleteCustomerCommand(id);

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Customer_Has_Active_Orders()
        {
            // Arrange
            var customerId = 1;
            var customer = new Domain.Entities.Customer
            {
                Id = customerId,
                Name = "Test Customer",
                Orders = new List<Domain.Entities.Order>
                {
                    new Domain.Entities.Order { Id = 1, CustomerId = customerId }
                }
            };

            var command = new DeleteCustomerCommand(customerId);

            _customerRepositoryMock.Setup(x => x.GetById(customerId))
                .ReturnsAsync(customer);

            //Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);       
            
            //Assert
            act.Should().ThrowAsync<InvalidOperationException>();

            _customerRepositoryMock.Verify(x => x.DeleteById(customerId), Times.Never);
        }
    }
}
