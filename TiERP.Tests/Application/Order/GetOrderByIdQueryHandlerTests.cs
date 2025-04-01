using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.Queries.GetCustomerById;
using TiErp.Application.Order.Commands.DeleteOrder;
using TiErp.Application.Order.DTOs;
using TiErp.Application.Order.Queries.GetOrderById;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Order
{
    public class GetOrderByIdQueryHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<GetOrderByIdQuery, OrderDto> _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        public GetOrderByIdQueryHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new GetOrderByIdQueryHandler(
                _orderRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_Return_Order_When_Order_Exists()
        {
            // Arrange
            var orderId = 1;
            var existingOrder = new Domain.Entities.Order
            {
                Id = orderId,
                DeadLine = DateOnly.Parse("2025-12-31"),
                CustomerId = 1,
                CreatedById = "user_1",
                Items = new List<OrderItem>
                {
                    new OrderItem { Id = 1, ProductId = 1, Quantity = 10 },
                    new OrderItem { Id = 2, ProductId = 2, Quantity = 5 }
                }
            };
            _orderRepositoryMock.Setup(x => x.GetById(orderId))
                .ReturnsAsync(existingOrder);

            _mapperMock.Setup(x => x.Map<OrderDto>(existingOrder))
                .Returns(new OrderDto
                {
                    Id = existingOrder.Id,
                    DeadLine = existingOrder.DeadLine,
                    CustomerId = existingOrder.CustomerId,
                    CreatedById = existingOrder.CreatedById,
                    Items = existingOrder.Items
                });

            var query = new GetOrderByIdQuery(orderId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(orderId);
            result.DeadLine.Should().Be(existingOrder.DeadLine);
            result.CustomerId.Should().Be(existingOrder.CustomerId);
            result.CreatedById.Should().Be(existingOrder.CreatedById);
            result.Items.Should().HaveCount(existingOrder.Items.Count);

            _orderRepositoryMock.Verify(x => x.GetById(orderId), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_Null_When_Order_Does_Not_Exist()
        {
            // Arrange
            var nonExistentOrderId = 999;

            _orderRepositoryMock.Setup(x => x.GetById(nonExistentOrderId))
                .ReturnsAsync((Domain.Entities.Order)null);

            var query = new GetOrderByIdQuery(nonExistentOrderId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}
