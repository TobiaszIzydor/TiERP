﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.OrderItem.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        public GetAllOrderItemsQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<IEnumerable<OrderItemDto>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            return dtos;
        }
    }
}
