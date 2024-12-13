using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Queries.GetAllProductionItems
{
    public class GetAllProductionItemsQueryHandler : IRequestHandler<GetAllProductionItemsQuery, IEnumerable<ProductionItemDto>>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        private readonly IMapper _mapper;
        public GetAllProductionItemsQueryHandler(IProductionItemRepository productionItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productionItemRepository = productionItemRepository;
        }
        public async Task<IEnumerable<ProductionItemDto>> Handle(GetAllProductionItemsQuery request, CancellationToken cancellationToken)
        {
            var productionItems = await _productionItemRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ProductionItemDto>>(productionItems);
            return dtos;
        }
    }
}
