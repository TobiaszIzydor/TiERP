using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Commands.EditProductionItem
{
    public class EditProductionItemCommandHandler : IRequestHandler<EditProductionItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductionItemRepository _productionItemRepository;
        public EditProductionItemCommandHandler(IProductionItemRepository productionItemRepository, IMapper mapper)
        {
            _productionItemRepository = productionItemRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditProductionItemCommand request, CancellationToken cancellationToken)
        {
            var updatedProductionItem = _mapper.Map<ProductionItemDto>(request);
            var productionItem = await _productionItemRepository.GetById(updatedProductionItem.Id);
            if (productionItem != null)
            {
                productionItem.EAN11 = updatedProductionItem.EAN11;
                productionItem.Quantity = updatedProductionItem.Quantity;
                productionItem.Name = updatedProductionItem.Name;
                await _productionItemRepository.Commit();
            }
            return Unit.Value;
        }
    }
}
