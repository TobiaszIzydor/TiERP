using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionItem.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionItem.Queries.GetAllProductionItemsForProduct
{
    public class GetAllProductionItemsForProductQueryHandler : IRequestHandler<GetAllProductionItemsForProductQuery, IEnumerable<ProductionItemDto>>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        private readonly IMapper _mapper;
        public GetAllProductionItemsForProductQueryHandler(IProductionItemRepository productionItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productionItemRepository = productionItemRepository;
        }
        public async Task<IEnumerable<ProductionItemDto>> Handle(GetAllProductionItemsForProductQuery request, CancellationToken cancellationToken)
        {
            var productionItems = await _productionItemRepository.GetAllForProduct(request.Id);
            var dtos = _mapper.Map<IEnumerable<ProductionItemDto>>(productionItems);
            return dtos;
        }
    }
}
