using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;

namespace TiWms.Application.OrderItem.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemDto>>
    {

    }
}
