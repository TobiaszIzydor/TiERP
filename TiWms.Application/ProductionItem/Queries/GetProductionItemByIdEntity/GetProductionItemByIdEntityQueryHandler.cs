using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Queries.GetProductionItemByIdEntity
{
    public class GetProductionItemByIdEntityQueryHandler : IRequestHandler<GetProductionItemByIdEntityQuery, Domain.Entities.ProductionItem>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        private readonly IMapper _mapper;
        public GetProductionItemByIdEntityQueryHandler(IProductionItemRepository productionItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productionItemRepository = productionItemRepository;
        }
        public async Task<Domain.Entities.ProductionItem> Handle(GetProductionItemByIdEntityQuery request, CancellationToken cancellationToken)
        {
            var productionItem = await _productionItemRepository.GetById(request.Id);
            return productionItem;
        }
    }
}
