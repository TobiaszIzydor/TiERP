using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TiWms.Application.Customer.Commands.CreateCustomer;
using TiWms.Application.Customer.Commands.DeleteCustomer;
using TiWms.Application.Customer.Queries.GetAllCustomers;
using TiWms.Application.Employee.Queries.GetAllLiders;
using TiWms.Application.ProductionLine.Commands.CreateProductionLine;
using TiWms.Application.ProductionLine.Commands.DeleteProductionLine;
using TiWms.Application.ProductionLine.Commands.EditProductionLine;
using TiWms.Application.ProductionLine.Queries.GetAllProductionLines;
using TiWms.Application.ProductionLine.Queries.GetProductionLineById;
using TiWms.MVC.Models;

namespace TiWms.MVC.Controllers
{
    public class ProductionLineController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductionLineController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Index()
        {
            var productionLines = await _mediator.Send(new GetAllProductionLinesQuery());
            return View(productionLines);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("ProductionLine/{id}/Details")]
        public IActionResult Details(int ProductionLineId)
        {
            return View();
        }

        [Authorize(Roles = "Kierownik, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Create(CreateProductionLineCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Create));
        }
        [Authorize(Roles = "Kierownik, Admin")]

        [Route("ProductionLine/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productionLine = await _mediator.Send(new GetProductionLineByIdQuery(id));
            if (productionLine == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<EditProductionLineCommand>(productionLine);
            var editProductionLineView = new EditProductionLineView
            {
                Liders = await _mediator.Send(new GetAllLidersQuery()),
                EditProductionLineCommand = mapped
            };
            return View(editProductionLineView);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductionLineView view)
        {
            await _mediator.Send(view.EditProductionLineCommand);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductionLineCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
