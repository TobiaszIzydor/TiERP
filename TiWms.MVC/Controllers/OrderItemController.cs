using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.ApplicationUser;
using TiWms.Application.Customer.Commands.DeleteCustomer;
using TiWms.Application.Customer.Queries.GetAllCustomers;
using TiWms.Application.Employee.Queries.GetEmployeeById;
using TiWms.Application.Order.Commands.EditOrder;
using TiWms.Application.Order.Queries.GetAllOrders;
using TiWms.Application.Order.Queries.GetOrderById;
using TiWms.Application.OrderItem.Commands.AddMade;
using TiWms.Application.OrderItem.Commands.DeleteOrderItem;
using TiWms.Application.OrderItem.Commands.EditOrderItem;
using TiWms.Application.OrderItem.DTOs;
using TiWms.Application.OrderItem.Queries.GetAllOrderItems;
using TiWms.Application.OrderItem.Queries.GetOrderItemById;
using TiWms.Application.OrderItem.Queries.GetOrderItemsForProductionLine;
using TiWms.Application.Product.Queries.GetAllProducts;

namespace TiWms.MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public OrderItemController(IMapper mapper, IMediator mediator, IUserContext userContext)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userContext = userContext;
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Index()
        {
            var orderItems = await _mediator.Send(new GetAllOrderItemsQuery());
            var mapped = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            return View(mapped);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("OrderItem/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Products = await _mediator.Send(new GetAllProductsQuery());
            ViewBag.Orders = await _mediator.Send(new GetAllOrdersQuery()); 
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery(id));
            if (orderItem == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<EditOrderItemCommand>(orderItem);
            return View(mapped);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [HttpPost]
        [Route("OrderItem/{id}/Edit")]
        public async Task<IActionResult> Edit(EditOrderItemCommand model)
        {
            ViewBag.Products = await _mediator.Send(new GetAllProductsQuery());
            ViewBag.Orders = await _mediator.Send(new GetAllOrdersQuery());
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Kierownik, Admin, Lider")]
        [Route("OrderItem/ForProductionLine/{id}")]
        public async Task<IActionResult> ForProductionLine(int id)
        {
            var orderItems = await _mediator.Send(new GetOrderItemsForProductionLineQuery(id));
            return View(orderItems);
        }
        [Authorize(Roles = "Kierownik, Admin, Lider")]
        [Route("OrderItem/Process/{id}")]
        public async Task<IActionResult> Process(int id)
        {
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery(id));
            return View(orderItem);
        }
        [Authorize(Roles = "Kierownik, Admin, Lider")]
        [HttpPost]
        public async Task<IActionResult> AddMade(int id)  // Parametr id bezpośrednio w akcji
        {
            await _mediator.Send(new AddMadeCommand(id));
            return RedirectToAction(nameof(Process), new { id });
        }
        [Authorize(Roles = "Kierownik, Admin, Lider")]
        public async Task<IActionResult> SelectToDo()
        {
            var currentUser = await _userContext.GetCurrentUserAsync();
            if (currentUser.EmployeeId.HasValue)
            {
                var employee = await _mediator.Send(new GetEmployeeByIdQuery(currentUser.EmployeeId.Value));
                if (employee == null)
                {
                    return NotFound("Pracownik nie został znaleziony.");
                }
                var productionLineId = employee.ProductionLineId;
               var orderItems = await _mediator.Send(new GetOrderItemsForProductionLineQuery(productionLineId));
                return View(orderItems);
            }
            return Unauthorized("Użytkownik nie ma przypisanego pracownika.");

        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderItemCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
