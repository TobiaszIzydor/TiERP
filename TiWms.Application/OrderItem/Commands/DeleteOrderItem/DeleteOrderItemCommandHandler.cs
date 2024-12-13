using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.OrderItem.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, Unit>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            await _orderItemRepository.DeleteById(request.Id);
            return Unit.Value;
        }
    }
}
