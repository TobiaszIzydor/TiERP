using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiErp.Application.Customer.Commands.DeleteCustomer;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Application.Customer.Queries.GetAllCustomers;
using TiErp.Application.Customer.Queries.GetCustomerById;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.Application.Order.Commands.DeleteOrder;
using TiErp.Application.Order.Commands.EditOrder;
using TiErp.Application.Order.Queries.GetAllOrders;
using TiErp.Application.Order.Queries.GetOrderById;
using TiErp.Application.Product.Queries.GetAllProducts;
using TiErp.Application.Product.Queries.GetAllProductsSimple;
using TiErp.Application.ProductionLine.Queries.GetAllProductionLines;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using TiErp.Infrastructure.Repositories;
using TiErp.MVC.Models;

namespace TiErp.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IMediator mediator, IMapper mapper, IProductionLineRepository productionLineRepository, IProductRepository productRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
            _productRepository = productRepository;
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Index()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return View(orders);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("Order/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var order = new Application.Order.DTOs.OrderDto();
            try
            {
                order = await _mediator.Send(new GetOrderByIdQuery(id));
            }
            catch(ArgumentException ex) {
                ViewBag.Error = ex.Message;
            }
            return View(order);
        }

        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Create()
        {   
            var model = new OrderViewModel()
            {
                Customers = await _mediator.Send(new GetAllCustomersQuery()),
                Products = await _mediator.Send(new GetAllProductsSimpleQuery()),
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Create(OrderViewModel view)
        {
            var order = new Order
            {
                Items = view.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList(),
                CustomerId = view.CustomerId,
                DeadLine = view.DeadLine,
            };
            await _mediator.Send(new CreateOrderCommand(order));
            return RedirectToAction(nameof(Create));
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("Order/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Customers = await _mediator.Send(new GetAllCustomersQuery());
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<EditOrderCommand>(order);
            return View(mapped);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [HttpPost]
        [Route("Order/{id}/Edit")]
        public async Task<IActionResult> Edit(EditOrderCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}

