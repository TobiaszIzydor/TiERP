using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.Services;
using TiWms.Domain.Entities;
using TiWms.MVC.Models;

namespace TiWms.MVC.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        await _employeeService.Create(employee);
        return RedirectToAction(nameof(Create));
    }
}
