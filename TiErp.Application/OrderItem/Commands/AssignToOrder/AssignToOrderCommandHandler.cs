using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.OrderItem.Commands.AssignToOrder
{
    public class AssignToOrderCommandHandler : IRequestHandler<AssignToOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        public AssignToOrderCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<bool> Handle(AssignToOrderCommand request, CancellationToken cancellationToken)
        {
            if(request.OrderId == 0)
            {
                return false;
            }
            if (request.OrderItemId == 0)
            {
                return false;
            }
            await _orderItemRepository.AssignToOrder(request.OrderId, request.OrderItemId);
            return true;

        }
    }
}
