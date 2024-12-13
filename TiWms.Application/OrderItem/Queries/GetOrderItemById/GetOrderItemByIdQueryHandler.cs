using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.OrderItem.Queries.GetOrderItemById
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        public GetOrderItemByIdQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderItemDto> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetById(request.Id);
            var dto = _mapper.Map<OrderItemDto>(orderItem);
            return dto;
        }
    }
}
