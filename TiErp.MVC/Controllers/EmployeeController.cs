using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiErp.Application.Employee.Commands.CreateEmployee;
using TiErp.Application.Employee.Queries;
using TiErp.Application.Employee.Queries.GetAllEmployees;
using TiErp.Application.Employee.DTOs;
using TiErp.Domain.Entities;
using TiErp.MVC.Models;
using TiErp.Application.ApplicationUser.GetAllUsers;
using TiErp.Application.Employee.Commands.SetEmployeeToUser;
using TiErp.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiErp.Application.ApplicationUser.GetAllRoles;
using TiErp.Application.Order.Queries.GetAllOrders;
using TiErp.Application.OrderItem.Commands.EditOrderItem;
using TiErp.Application.OrderItem.Queries.GetOrderItemById;
using TiErp.Application.Product.Queries.GetAllProducts;
using AutoMapper;
using TiErp.Application.ProductionLine.Queries.GetAllProductionLines;
using Microsoft.AspNetCore.Identity;
using TiErp.Application.Employee.Queries.GetEmployeeById;
using TiErp.Application.Employee.Commands.EditEmployee;
using TiErp.Application.Customer.Commands.DeleteCustomer;
using TiErp.Application.Employee.Commands.DeleteEmployee;

namespace TiErp.MVC.Controllers;

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
