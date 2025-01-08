using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionLine.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionLine.Queries.GetProductionLineById
{
    public class GetProductionLineByIdQueryHandler : IRequestHandler<GetProductionLineByIdQuery, ProductionLineDto>
    {
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly IMapper _mapper;
        public GetProductionLineByIdQueryHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
        }

        public async Task<ProductionLineDto> Handle(GetProductionLineByIdQuery request, CancellationToken cancellationToken)
        {
            var productionLine = await _productionLineRepository.GetById(request.Id);
            var dto = _mapper.Map<ProductionLineDto>(productionLine);
            return dto;
        }
    }
}
