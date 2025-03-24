using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;
using TiErp.Application.Order.Queries.GetAllOrders;
using TiErp.Application.Order.Queries.GetOrderById;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests.Application.Order
{
    public class GetAllOrdersQueryHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>> _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        public GetAllOrdersQueryHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new GetAllOrdersQueryHandler(
                _orderRepositoryMock.Object,
                _mapperMock.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_All_Orders()
        {
            // Arrange
            var orders = new List<Domain.Entities.Order>
            {
                new Domain.Entities.Order
                {
                    Id = 1,
                    DeadLine = DateOnly.Parse("2025-12-31"),
                    CustomerId = 1,
                    CreatedById = "user_1",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 1, ProductId = 1, Quantity = 10 },
                        new OrderItem { Id = 2, ProductId = 2, Quantity = 5 }
                    }
                },
                new Domain.Entities.Order
                {
                    Id = 2,
                    DeadLine = DateOnly.Parse("2025-11-30"),
                    CustomerId = 2,
                    CreatedById = "user_2",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Id = 3, ProductId = 3, Quantity = 15 }
                    }
                }
            };

            
            _orderRepositoryMock.Setup(x => x.GetAll())
                .ReturnsAsync(orders);

            _mapperMock.Setup(x => x.Map<IEnumerable<OrderDto>>(orders))
                .Returns(orders.Select(o => new OrderDto
                {
                    Id = o.Id,
                    DeadLine = o.DeadLine,
                    CustomerId = o.CustomerId,
                    CreatedById = o.CreatedById,
                    Items = o.Items.Select(i => new OrderItem
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity
                    }).ToList()
                }).ToList());

            var query = new GetAllOrdersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);

            var firstOrder = result.First();
            firstOrder.Id.Should().Be(1);
            firstOrder.Items.Should().HaveCount(2);

            var secondOrder = result.Last();
            secondOrder.Id.Should().Be(2);
            secondOrder.Items.Should().HaveCount(1);

            _orderRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<OrderDto>>(orders), Times.Once);
        }
    }
}
