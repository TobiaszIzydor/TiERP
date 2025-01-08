using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;

namespace TiErp.Application.OrderItem.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : OrderItemDto, IRequest<Unit>
    {
    }
}
