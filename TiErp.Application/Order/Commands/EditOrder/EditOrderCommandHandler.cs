﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Order.Commands.EditOrder
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public EditOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var updatedOrder = _mapper.Map<OrderDto>(request);
            var order = await _orderRepository.GetById(updatedOrder.Id);
            if(order != null)
            {
                if(updatedOrder.CustomerId != 0)
                {
                    order.CustomerId = updatedOrder.CustomerId;
                }

                order.DeadLine = (DateOnly)updatedOrder.DeadLine;
                await _orderRepository.Commit();
            }
            else
            {
                throw new ArgumentNullException(nameof(request));
            }
            return Unit.Value;

        }
    }
}
