﻿using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.Customer.DTOs;
using TiWms.Domain.Entities;
using TiWms.MVC.Models;
using TiWms.Application.Customer.Queries.GetAllCustomers;
using TiWms.Application.Customer.Commands.CreateCustomer;
using TiWms.Application.Customer.Queries.GetCustomerById;
using TiWms.Application.Employee.Queries.GetAllLiders;
using TiWms.Application.ProductionLine.Commands.EditProductionLine;
using TiWms.Application.ProductionLine.Queries.GetProductionLineById;
using AutoMapper;
using TiWms.Application.Customer.Commands.EditCustomer;
using TiWms.Application.Customer.Commands.DeleteCustomer;

namespace TiWms.MVC.Controllers;

public class CustomerController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {

        var Customers = await _mediator.Send(new GetAllCustomersQuery());
        return View(Customers);
    }
    [Route("Customer/{id}/Details")]
    public async Task<IActionResult> Details(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        return View(customer);
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

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
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
        return RedirectToAction(nameof(Index));
    }
}
