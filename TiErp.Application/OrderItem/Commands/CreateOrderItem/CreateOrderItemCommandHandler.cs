using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.OrderItem.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        public CreateOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<Unit> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var productionItem = _mapper.Map<Domain.Entities.OrderItem>(request);
            await _orderItemRepository.Create(productionItem);
            return Unit.Value;
        }
    }
}
