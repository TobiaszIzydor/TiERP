using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.OrderItem.Commands.EditOrderItem
{
    public class EditOrderItemCommandHandler : IRequestHandler<EditOrderItemCommand, Unit>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        public EditOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<Unit> Handle(EditOrderItemCommand request, CancellationToken cancellationToken)
        {
            var updatedOrderItem = _mapper.Map<OrderItemDto>(request);
            var orderItem = await _orderItemRepository.GetById(updatedOrderItem.Id);
            if (orderItem != null)
            {
                orderItem.Quantity = updatedOrderItem.Quantity;
                orderItem.Status = updatedOrderItem.Status;
                orderItem.ProductId = updatedOrderItem.ProductId;
                orderItem.OrderId = updatedOrderItem.OrderId;
                await _orderItemRepository.Commit();
            }
            return Unit.Value;
        }
    }
}
