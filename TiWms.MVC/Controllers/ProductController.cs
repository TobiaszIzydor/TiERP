using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TiWms.Application.Customer.Commands.DeleteCustomer;
using TiWms.Application.Order.Queries.GetAllOrders;
using TiWms.Application.Order.Queries.GetOrderById;
using TiWms.Application.OrderItem.Commands.EditOrderItem;
using TiWms.Application.OrderItem.Queries.GetOrderItemById;
using TiWms.Application.Product.Commands.CreateProduct;
using TiWms.Application.Product.Commands.DeleteProduct;
using TiWms.Application.Product.Commands.EditProduct;
using TiWms.Application.Product.DTOs;
using TiWms.Application.Product.Queries.GetAllProducts;
using TiWms.Application.Product.Queries.GetProductById;
using TiWms.Application.ProductionItem.Queries.GetAllProductionItems;
using TiWms.Application.ProductionItem.Queries.GetProductionItemById;
using TiWms.Application.ProductionItem.Queries.GetProductionItemByIdEntity;
using TiWms.Application.ProductionLine.Commands.CreateProductionLine;
using TiWms.Application.ProductionLine.Queries.GetAllProductionLines;
using TiWms.Application.ProductionLine.Queries.GetProductionLineById;
using TiWms.Domain.Interfaces;
using TiWms.MVC.Models;

namespace TiWms.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProductionLineRepository _productionLineRepository;

        public ProductController(IMediator mediator, IMapper mapper, IProductionLineRepository productionLineRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }
        [Route("Product/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductView
            {
                productionLines = await _mediator.Send(new GetAllProductionLinesQuery()),
                AvailableProductionItems = await _mediator.Send(new GetAllProductionItemsQuery())
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductView view)
        {
            var productionLine = await _productionLineRepository.GetById(view.ProductionLineId);
            view.CreateProductCommand.ProductionLine = productionLine;
            view.CreateProductCommand.Name = view.Name;


            foreach (var id in view.SelectedProductionItemIds)
            {
                var productionItem = await _mediator.Send(new GetProductionItemByIdEntityQuery(id));
                if (productionItem != null)
                {
                    view.CreateProductCommand.ProductionItems.Add(productionItem);
                }
            }

            await _mediator.Send(view.CreateProductCommand);
            return RedirectToAction(nameof(Index));
        }
        [Route("Product/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            var model = new EditProductView
            {
                Id = product.Id,
                Name = product.Name,
                SelectedProductionItemIds = product.ProductionItems.Select(p => p.Id).ToList(),
                ProductionLineId = product.ProductionLine.Id,
                productionLines = await _mediator.Send(new GetAllProductionLinesQuery()),
                AvailableProductionItems = await _mediator.Send(new GetAllProductionItemsQuery()),
            };
            return View(model);
        }

        [HttpPost]
        [Route("Product/{id}/Edit")]
        public async Task<IActionResult> Edit(EditProductView view)
        {
            var productionLine = await _productionLineRepository.GetById(view.ProductionLineId);
            view.EditProductCommand.ProductionLine = productionLine;
            view.EditProductCommand.Name = view.Name;
            view.EditProductCommand.Id = view.Id;


            foreach (var id in view.SelectedProductionItemIds)
            {
                var productionItem = await _mediator.Send(new GetProductionItemByIdEntityQuery(id));
                if (productionItem != null)
                {
                    view.EditProductCommand.ProductionItems.Add(productionItem);
                }
            }

            await _mediator.Send(view.EditProductCommand);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }

}
