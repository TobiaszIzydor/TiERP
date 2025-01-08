using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.Id);
            var itemsToDelete = order.Items.ToList();

            foreach (var item in itemsToDelete)
            {
                await _orderItemRepository.DeleteById(item.Id);
            }
            await _orderRepository.DeleteById(request.Id);
            return Unit.Value;
        }
    }
}
