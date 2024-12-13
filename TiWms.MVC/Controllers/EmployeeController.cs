using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.Employee.Commands.CreateEmployee;
using TiWms.Application.Employee.Queries;
using TiWms.Application.Employee.Queries.GetAllEmployees;
using TiWms.Application.Employee.DTOs;
using TiWms.Domain.Entities;
using TiWms.MVC.Models;
using TiWms.Application.ApplicationUser.GetAllUsers;
using TiWms.Application.Employee.Commands.SetEmployeeToUser;
using TiWms.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiWms.Application.ApplicationUser.GetAllRoles;
using TiWms.Application.Order.Queries.GetAllOrders;
using TiWms.Application.OrderItem.Commands.EditOrderItem;
using TiWms.Application.OrderItem.Queries.GetOrderItemById;
using TiWms.Application.Product.Queries.GetAllProducts;
using AutoMapper;
using TiWms.Application.ProductionLine.Queries.GetAllProductionLines;
using Microsoft.AspNetCore.Identity;
using TiWms.Application.Employee.Queries.GetEmployeeById;
using TiWms.Application.Employee.Commands.EditEmployee;
using TiWms.Application.Customer.Commands.DeleteCustomer;
using TiWms.Application.Employee.Commands.DeleteEmployee;

namespace TiWms.MVC.Controllers;

public class EmployeeController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public EmployeeController(IMediator mediator, IMapper mapper, UserManager<ApplicationUser>userManager)
    {
        _mediator = mediator;
        _mapper = mapper;
        _userManager = userManager;
    }
    [Authorize(Roles = "Kierownik, Admin")]
    public async Task<IActionResult> Index()
    {

        var employees = await _mediator.Send(new GetAllEmployeesQuery());
        return View(employees);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    public async Task<IActionResult> Details(int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        return View(employee);
    }

    [Authorize(Roles = "Kierownik, Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Kierownik, Admin")]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Create));
    }
    [Authorize(Roles = "Kierownik, Admin")]
    public async Task<IActionResult> AssignToUser()
    {
        var model = new EmployeeAssignToUserView
        {
            Users = await _mediator.Send(new GetAllUsersQuery()),
            Employees = await _mediator.Send(new GetAllEmployeesQuery())
        };

        return View(model);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [HttpPost]
    public async Task<IActionResult> AssignToUser(EmployeeAssignToUserView modelview)
    {
        var command = await _mediator.Send(new SetEmployeeToUserCommand(modelview.EmployeeId, modelview.UserId));

        return RedirectToAction(nameof(AssignToUser)); 
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [Route("Employee/{id}/Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        ViewBag.ProductionLines = await _mediator.Send(new GetAllProductionLinesQuery());
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
        {
            return NotFound();
        }
        var mapped = _mapper.Map<EditEmployeeCommand>(employee);
        return View(mapped);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [HttpPost]
    [Route("Employee/{id}/Edit")]
    public async Task<IActionResult> Edit(EditEmployeeCommand model)
    {
        ViewBag.ProductionLines = await _mediator.Send(new GetAllProductionLinesQuery());
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
        await _mediator.Send(new DeleteEmployeeCommand(id));
        return RedirectToAction(nameof(Index));
    }
}
