using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionLine.Commands.DeleteProductionLine
{
    public class DeleteProductionLineCommandHandler : IRequestHandler<DeleteProductionLineCommand, Unit>
    {
        private readonly IProductionLineRepository _productionLineRepository;
        public DeleteProductionLineCommandHandler(IProductionLineRepository productionLineRepository)
        {
            _productionLineRepository = productionLineRepository;
        }
        public async Task<Unit> Handle(DeleteProductionLineCommand request, CancellationToken cancellationToken)
        {
            await _productionLineRepository.DeleteById(request.Id);
            return Unit.Value;
        }
    }
}
