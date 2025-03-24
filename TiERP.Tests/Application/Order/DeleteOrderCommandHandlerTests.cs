using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.Commands.DeleteOrder;
using TiErp.Application.Order.Commands.EditOrder;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TiErp.Tests.Application.Order
{
    public class DeleteOrderCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<DeleteOrderCommand, Unit> _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IOrderItemRepository> _orderItemRepositoryMock;
        public DeleteOrderCommandHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderItemRepositoryMock = new Mock<IOrderItemRepository>();
            _handler = new DeleteOrderCommandHandler(
                _orderRepositoryMock.Object,
                _orderItemRepositoryMock.Object
            );
        }
        [Fact]
        public async Task Handle_Should_Delete_Order_When_Order_Exists()
        {
            // Arrange
            var existingOrder = new Domain.Entities.Order
            {
                Id = 1,
                DeadLine = DateOnly.Parse("2025-12-31"),
                CustomerId = 1,
                CreatedById = "user_1",
                Items = new List<OrderItem>()
            };

            _orderRepositoryMock.Setup(x => x.GetById(existingOrder.Id))
                .ReturnsAsync(existingOrder);
            _orderItemRepositoryMock.Setup(x => x.GetByOrderId(existingOrder.Id))
                .ReturnsAsync(existingOrder.Items);
            _orderItemRepositoryMock.Setup(x => x.DeleteById(It.IsAny<int>()))
                .Returns(Task.CompletedTask);
            _orderRepositoryMock.Setup(x => x.DeleteById(existingOrder.Id))
                .Returns(Task.CompletedTask);

            var command = new DeleteOrderCommand(existingOrder.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            foreach (var item in existingOrder.Items)
            {
                _orderItemRepositoryMock.Verify(x => x.DeleteById(item.Id), Times.Once);
            }

            _orderRepositoryMock.Verify(x => x.DeleteById(existingOrder.Id), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Order_Does_Not_Exist()
        {
            int id = 1;
            // Arrange
            _orderRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync((Domain.Entities.Order)null);

            var command = new DeleteOrderCommand(id);

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
