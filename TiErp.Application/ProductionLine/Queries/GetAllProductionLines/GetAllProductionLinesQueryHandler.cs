using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionLine.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionLine.Queries.GetAllProductionLines
{
    public class GetAllProductionLinesQueryHandler : IRequestHandler<GetAllProductionLinesQuery, IEnumerable<ProductionLineDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductionLineRepository _productionLineRepository;
        public GetAllProductionLinesQueryHandler(IMapper mapper, IProductionLineRepository productionLineRepository)
        {
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
        }
        public async Task<IEnumerable<ProductionLineDto>> Handle(GetAllProductionLinesQuery request, CancellationToken cancellationToken)
        {
            var productionLines = await _productionLineRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ProductionLineDto>>(productionLines);
            return dtos;
        }
    }
}
