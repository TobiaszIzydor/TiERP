using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.Id);
            var dto = _mapper.Map<OrderDto>(order);
            return dto;
        }
    }
}
