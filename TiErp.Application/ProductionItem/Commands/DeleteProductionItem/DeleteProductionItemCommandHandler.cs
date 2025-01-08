using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ProductionItem.Commands.DeleteProductionItem
{
    public class DeleteProductionItemCommandHandler : IRequestHandler<DeleteProductionItemCommand, Unit>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        public DeleteProductionItemCommandHandler(IProductionItemRepository productionItemRepository)
        {
            _productionItemRepository = productionItemRepository;
        }
        public async Task<Unit> Handle(DeleteProductionItemCommand request, CancellationToken cancellationToken)
        {
            await _productionItemRepository.DeleteById(request.Id);
            return Unit.Value;
        }
    }
}
