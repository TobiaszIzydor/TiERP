using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.OrderItem.Commands.AddMade
{
    public class AddMadeCommandHandler : IRequestHandler<AddMadeCommand, Unit>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public AddMadeCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<Unit> Handle(AddMadeCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetById(request.Id);
            if (orderItem.Quantity-1 == orderItem.Made)
            {
                orderItem.Made++;
                orderItem.Status = Domain.Entities.Status.Done;
            }
            else if (orderItem.Quantity == orderItem.Made)
            {
                return Unit.Value;
            }
            else if (orderItem.Made == 0)
            {
                orderItem.Status = Domain.Entities.Status.InProgress;
                orderItem.Made++;
            }
            else
            {
                orderItem.Made++;
            }
            await _orderItemRepository.Commit();
            return Unit.Value;
        }
    }
}
