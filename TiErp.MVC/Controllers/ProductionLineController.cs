using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TiErp.Application.Customer.Commands.CreateCustomer;
using TiErp.Application.Customer.Commands.DeleteCustomer;
using TiErp.Application.Customer.Queries.GetAllCustomers;
using TiErp.Application.Employee.Queries.GetAllLiders;
using TiErp.Application.ProductionLine.Commands.CreateProductionLine;
using TiErp.Application.ProductionLine.Commands.DeleteProductionLine;
using TiErp.Application.ProductionLine.Commands.EditProductionLine;
using TiErp.Application.ProductionLine.Queries.GetAllProductionLines;
using TiErp.Application.ProductionLine.Queries.GetProductionLineById;
using TiErp.MVC.Models;

namespace TiErp.MVC.Controllers
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
        [Route("ProductionLine/{id}/Edit")]
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
