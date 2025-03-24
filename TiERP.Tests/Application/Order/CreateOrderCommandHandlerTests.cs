using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using TiErp.Application.ApplicationUser;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.Application.Order.DTOs;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;

namespace TiErp.Tests;

public class CreateOrderCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly Mock<ICustomerRepository> _customerRepositoryMock;
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly IRequestHandler<CreateOrderCommand, Unit> _handler;

    public CreateOrderCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _userContextMock = new Mock<IUserContext>();
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _orderRepositoryMock = new Mock<IOrderRepository>();

        _handler = new CreateOrderCommandHandler(
            _orderRepositoryMock.Object,
            _mapperMock.Object,
            _userContextMock.Object,
            _customerRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_Should_Create_Order_When_Valid_Command()
    {
        // Arrange
        var orderDto = new OrderDto
        {
            CustomerId = 1,
            DeadLine = DateOnly.Parse("2025-12-31"),
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = 1, Quantity = 10 },
                new OrderItem { ProductId = 2, Quantity = 5 }
            }
        };

        var user = new ApplicationUser { Id = "user_1", Email = "email@email.com" };
        var customer = new Customer { Id = 1, Name = "Test Customer", Address = "Poznan", Phone = "112345678" };

        _userContextMock.Setup(x => x.GetCurrentUserAsync())
            .ReturnsAsync(new CurrentUser(user.Id, user.Email, null, new List<string> { "Admin" }));

        _customerRepositoryMock.Setup(x => x.GetById(1))
            .ReturnsAsync(customer);

        var mappedOrder = new Domain.Entities.Order
        {
            CustomerId = orderDto.CustomerId,
            DeadLine = (DateOnly)orderDto.DeadLine,
            CreatedById = user.Id,
            Items = orderDto.Items
        };

        _mapperMock.Setup(x => x.Map<Domain.Entities.Order>(It.IsAny<Order>()))
            .Returns((Order dto) => new Domain.Entities.Order
            {
                CustomerId = dto.CustomerId,
                DeadLine = (DateOnly)dto.DeadLine,
                CreatedById = user.Id,
                Items = dto.Items ?? new List<OrderItem>()
            });

        var command = new CreateOrderCommand(mappedOrder);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);

        _orderRepositoryMock.Verify(x => x.Create(It.Is<Domain.Entities.Order>(o =>
            o.CustomerId == orderDto.CustomerId &&
            o.DeadLine == (DateOnly)orderDto.DeadLine &&
            o.CreatedById == user.Id &&
            o.Items.Count == orderDto.Items.Count
        )), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Throw_ArgumentNullException_When_Order_Is_Null()
    {
        // Arrange
        var command = new CreateOrderCommand { Order = null };

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task Handle_Should_Throw_ArgumentException_When_Customer_Not_Found()
    {
        // Arrange
        var command = new CreateOrderCommand
        {
            Order = new Domain.Entities.Order { CustomerId = 1 }
        };

        var user = new ApplicationUser { Id = "user_1" };
        _mapperMock.Setup(x => x.Map<Domain.Entities.Order>(It.IsAny<Order>()))
            .Returns((Order dto) => new Domain.Entities.Order
            {
                CustomerId = dto.CustomerId,
                DeadLine = (DateOnly)dto.DeadLine,
                CreatedById = user.Id,
                Items = dto.Items ?? new List<OrderItem>()
            });

        _userContextMock.Setup(x => x.GetCurrentUserAsync())
            .ReturnsAsync(new CurrentUser(user.Id, user.Email, null, new List<string> { "Admin" }));

        _customerRepositoryMock.Setup(x => x.GetById(1))
            .ReturnsAsync((Customer)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }
}