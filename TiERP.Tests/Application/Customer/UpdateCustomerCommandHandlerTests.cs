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
using TiErp.Application.Customer.Commands.CreateCustomer;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Application.Customer.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Customer
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<EditCustomerCommand, Unit> _handler;
        public UpdateCustomerCommandHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new EditCustomerCommandHandler
            (
                _customerRepositoryMock.Object,
                _mapperMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Update_Customer_When_Valid_Command()
        {
            //Arrange
            var initialAddress = "Testowa 1, Poznan";
            var updatedAdress = "Przykladowa 2, Warszawa";
            var initialPhone = "111222333";
            var updatedPhone = "222444666";
            var existingCustomer = new Domain.Entities.Customer
            {
                Id = 1,
                Name = "Test",
                Address = initialAddress,
                Phone = initialPhone,
            };

            _customerRepositoryMock.Setup(x => x.GetById(existingCustomer.Id))
                .ReturnsAsync(existingCustomer);
            _customerRepositoryMock.Setup(x => x.Commit())
                .Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<CustomerDto>(It.IsAny<EditCustomerCommand>()))
                .Returns((EditCustomerCommand c) => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    CreatedById = c.CreatedById,
                });

            var command = new EditCustomerCommand
            {
                Id = existingCustomer.Id,
                Name = existingCustomer.Name,
                Address = updatedAdress,
                Phone = updatedPhone,
            };

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().Be(Unit.Value);

            existingCustomer.Phone.Should().Be(updatedPhone);
            existingCustomer.Address.Should().Be(updatedAdress);

            _customerRepositoryMock.Verify(x => x.Commit(), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Customer_Does_Not_Exist()
        {
            //Arrange
            var initialAddress = "Testowa 1, Poznan";
            var initialPhone = "111222333";

            _customerRepositoryMock.Setup(x => x.GetById(1))
                .ReturnsAsync((Domain.Entities.Customer)null);
            _customerRepositoryMock.Setup(x => x.Commit())
                .Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<CustomerDto>(It.IsAny<EditCustomerCommand>()))
                .Returns((EditCustomerCommand c) => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    CreatedById = c.CreatedById,
                });

            var command = new EditCustomerCommand
            {
                Id = 1,
                Name = "Test",
                Address = initialAddress,
                Phone = initialPhone,
            };

            //Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
