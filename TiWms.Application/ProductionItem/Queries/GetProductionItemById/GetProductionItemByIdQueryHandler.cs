using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Queries.GetProductionItemById
{
    public class GetProductionItemByIdEntityQueryHandler : IRequestHandler<GetProductionItemByIdQuery, ProductionItemDto>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        private readonly IMapper _mapper;
        public GetProductionItemByIdEntityQueryHandler(IProductionItemRepository productionItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productionItemRepository = productionItemRepository;
        }
        public async Task<ProductionItemDto> Handle(GetProductionItemByIdQuery request, CancellationToken cancellationToken)
        {
            var productionItem = await _productionItemRepository.GetById(request.Id);
            var dto = _mapper.Map<ProductionItemDto>(productionItem);
            return dto;
        }
    }
}
