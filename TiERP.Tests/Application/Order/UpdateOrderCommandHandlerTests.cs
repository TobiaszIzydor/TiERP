using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.Application.Order.Commands.EditOrder;
using TiErp.Application.Order.DTOs;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using TiErp.Infrastructure.Persistence;
using TiErp.Infrastructure.Repositories;
using TiErp.Tests.Common;

namespace TiErp.Tests.Application.Order
{
    public class UpdateOrderCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<EditOrderCommand, Unit> _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        public UpdateOrderCommandHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new EditOrderCommandHandler(
                _orderRepositoryMock.Object,
                _mapperMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Update_Order_When_Valid_Command()
        {
            // Arrange
            var orderId = 1;
            var initialDeadLine = DateOnly.Parse("2025-12-31");
            var updatedDeadLine = DateOnly.Parse("2025-11-30");
            var updatedCustomerId = 2;

            var existingOrder = new Domain.Entities.Order
            {
                Id = orderId,
                DeadLine = initialDeadLine,
                CustomerId = 1,
                CreatedById = "user_1",
                Items = new List<OrderItem>()
            };

            _orderRepositoryMock.Setup(x => x.GetById(orderId))
                .ReturnsAsync(existingOrder);
            _orderRepositoryMock.Setup(x => x.Commit())
                .Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<OrderDto>(It.IsAny<EditOrderCommand>()))
                .Returns((EditOrderCommand command) => new OrderDto
                {
                    Id = command.Id,
                    DeadLine = command.DeadLine,
                    CustomerId = command.CustomerId,
                    CreatedById = command.CreatedById,
                    Items = command.Items
                });

            var command = new EditOrderCommand
            {
                Id = orderId,
                DeadLine = updatedDeadLine,
                CustomerId = updatedCustomerId,
                CreatedById = "user_1",
                Items = new List<OrderItem>()
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            existingOrder.CustomerId.Should().Be(updatedCustomerId);
            existingOrder.DeadLine.Should().Be(updatedDeadLine);

            _orderRepositoryMock.Verify(x => x.Commit(), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Order_Does_Not_Exist()
        {
            // Arrange
            var orderId = 1;
            var deadLine = DateOnly.Parse("2025-12-31");

            _orderRepositoryMock.Setup(x => x.GetById(orderId))
                .ReturnsAsync((Domain.Entities.Order)null);

            _orderRepositoryMock.Setup(x => x.Commit())
                .Returns(Task.CompletedTask);

            _mapperMock.Setup(x => x.Map<OrderDto>(It.IsAny<EditOrderCommand>()))
                .Returns((EditOrderCommand command) => new OrderDto
                {
                    Id = command.Id,
                    DeadLine = command.DeadLine,
                    CustomerId = command.CustomerId,
                    CreatedById = command.CreatedById,
                    Items = command.Items
                });

            var command = new EditOrderCommand
            {
                Id = orderId,
                DeadLine = deadLine,
                CustomerId = 1,
                CreatedById = "user_1",
                Items = new List<OrderItem>()
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
