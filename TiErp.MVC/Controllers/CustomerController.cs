using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiErp.Application.Customer.DTOs;
using TiErp.Domain.Entities;
using TiErp.MVC.Models;
using TiErp.Application.Customer.Queries.GetAllCustomers;
using TiErp.Application.Customer.Commands.CreateCustomer;
using TiErp.Application.Customer.Queries.GetCustomerById;
using TiErp.Application.Employee.Queries.GetAllLiders;
using TiErp.Application.ProductionLine.Commands.EditProductionLine;
using TiErp.Application.ProductionLine.Queries.GetProductionLineById;
using AutoMapper;
using TiErp.Application.Customer.Commands.EditCustomer;
using TiErp.Application.Customer.Commands.DeleteCustomer;

namespace TiErp.MVC.Controllers;

public class CustomerController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [Authorize(Roles ="Kierownik, Admin")]
    public async Task<IActionResult> Index()
    {

        var Customers = await _mediator.Send(new GetAllCustomersQuery());
        return View(Customers);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [Route("Customer/{id}/Details")]
    public async Task<IActionResult> Details(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        return View(customer);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Create));
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [Route("Customer/{id}/Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null)
        {
            return NotFound();
        }
        var mapped = _mapper.Map<EditCustomerCommand>(customer);
        return View(mapped);
    }
    [Authorize(Roles = "Kierownik, Admin")]
    [HttpPost]
    [Route("Customer/{id}/Edit")]
    public async Task<IActionResult> Edit(EditCustomerCommand model)
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
        await _mediator.Send(new DeleteCustomerCommand(id));
        return RedirectToAction(nameof(Index));
    }
}
