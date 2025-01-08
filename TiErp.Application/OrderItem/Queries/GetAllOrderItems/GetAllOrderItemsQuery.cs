using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;

namespace TiErp.Application.OrderItem.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemDto>>
    {

    }
}
