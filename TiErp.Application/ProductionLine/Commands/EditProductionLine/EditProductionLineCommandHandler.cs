using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionLine.Commands.EditProductionLine
{
    public class EditProductionLineCommandHandler : IRequestHandler<EditProductionLineCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductionLineRepository _productionLineRepository;
        public EditProductionLineCommandHandler(IMapper mapper, IProductionLineRepository productionLineRepository)
        {
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
        }
        public async Task<Unit> Handle(EditProductionLineCommand request, CancellationToken cancellationToken)
        {
            var productionLine = _mapper.Map<Domain.Entities.ProductionLine>(request);
            await _productionLineRepository.Update(productionLine);
            return Unit.Value;
        }
    }
}
