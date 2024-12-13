using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.OrderItem.Queries.GetOrderItemsByOrderId
{
    public class GetOrderITemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        public GetOrderITemsByOrderIdQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<IEnumerable<OrderItemDto>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetByOrderId(request.Id);
            var dto =  _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            return dto;
        }
    }
}
