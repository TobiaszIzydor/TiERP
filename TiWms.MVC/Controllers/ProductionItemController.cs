using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.Customer.Commands.DeleteCustomer;
using TiWms.Application.Employee.Queries.GetAllLiders;
using TiWms.Application.ProductionItem.Commands.CreateProductionItem;
using TiWms.Application.ProductionItem.Commands.DeleteProductionItem;
using TiWms.Application.ProductionItem.Commands.EditProductionItem;
using TiWms.Application.ProductionItem.Queries.GetAllProductionItems;
using TiWms.Application.ProductionItem.Queries.GetAllProductionItemsForProduct;
using TiWms.Application.ProductionItem.Queries.GetProductionItemById;
using TiWms.Application.ProductionLine.Commands.CreateProductionLine;
using TiWms.Application.ProductionLine.Commands.EditProductionLine;
using TiWms.Application.ProductionLine.Queries.GetAllProductionLines;
using TiWms.Application.ProductionLine.Queries.GetProductionLineById;
using TiWms.MVC.Models;

namespace TiWms.MVC.Controllers
{
    public class ProductionItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductionItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Index()
        {
            var productionItems = await _mediator.Send(new GetAllProductionItemsQuery());
            return View(productionItems);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("/ProductionItem/ForProduct/{id}")]
        public async Task<IActionResult> ProductionItemsForProduct(int id)
        {
            var productionItems = await _mediator.Send(new GetAllProductionItemsForProductQuery(id));
            return View(productionItems);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("ProductionItem/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var productionItem = await _mediator.Send(new GetProductionItemByIdQuery(id));
            return View(productionItem);
        }

        [Authorize(Roles = "Kierownik, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Kierownik, Admin")]
        public async Task<IActionResult> Create(CreateProductionItemCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Create));
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [Route("ProductionItem/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productionItem = await _mediator.Send(new GetProductionItemByIdQuery(id));
            if (productionItem == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<EditProductionItemCommand>(productionItem);
            return View(mapped);
        }
        [Authorize(Roles = "Kierownik, Admin")]
        [HttpPost]
        [Route("ProductionItem/{id}/Edit")]
        public async Task<IActionResult> Edit(EditProductionItemCommand model)
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
            await _mediator.Send(new DeleteProductionItemCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
