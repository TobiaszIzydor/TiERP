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
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Customer
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly IRequestHandler<CreateCustomerCommand, Unit> _handler;
        public CreateCustomerCommandHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _userContextMock = new Mock<IUserContext>();
            _handler = new CreateCustomerCommandHandler
            (
                _customerRepositoryMock.Object,
                _mapperMock.Object,
                _userContextMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_Create_Customer_When_Valid_Command()
        {
            // Arrange
            var customerCommand = new CreateCustomerCommand
            {
                Id = 1,
                Name = "Test Customer",
                Address = "Poznan",
                Phone = "112345678"
            };
            var user = new ApplicationUser { Id = "user_1", Email = "email@email.com" };

            _userContextMock.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new CurrentUser(user.Id, user.Email, null, new List<string> { "Admin" }));

            _mapperMock.Setup(x => x.Map<Domain.Entities.Customer>(It.IsAny<CreateCustomerCommand>()))
                .Returns((CreateCustomerCommand dto) => new Domain.Entities.Customer
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    CreatedById = dto.CreatedById,
                });

            // Act
            var result = await _handler.Handle(customerCommand, CancellationToken.None);
            // Assert
            result.Should().Be(Unit.Value);

            _customerRepositoryMock.Verify(x => x.Create(It.Is<Domain.Entities.Customer>(o =>
                o.Id == customerCommand.Id &&
                o.Name == customerCommand.Name &&
                o.Address == customerCommand.Address &&
                o.Phone == customerCommand.Phone &&
                o.CreatedById == user.Id
            )), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Name_Is_Empty()
        {
            // Arrange
            var customerCommand = new CreateCustomerCommand
            {
                Id = 1,
                Address = "Poznan",
                Phone = "112345678"
            };
            var user = new ApplicationUser { Id = "user_1", Email = "email@email.com" };

            _userContextMock.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new CurrentUser(user.Id, user.Email, null, new List<string> { "Admin" }));

            _mapperMock.Setup(x => x.Map<Domain.Entities.Customer>(It.IsAny<CreateCustomerCommand>()))
                .Returns((CreateCustomerCommand dto) => new Domain.Entities.Customer
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    CreatedById = dto.CreatedById,
                });

            // Act
            Func<Task> act = async () => await _handler.Handle(customerCommand, CancellationToken.None);
            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
