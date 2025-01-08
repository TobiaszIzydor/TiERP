using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;

namespace TiErp.Application.OrderItem.Queries.GetOrderItemsByOrderId
{
    public class GetOrderItemsByOrderIdQuery : IRequest<IEnumerable<OrderItemDto>>
    {
        public int Id { get; set; }
        public GetOrderItemsByOrderIdQuery(int id)
        {
            Id = id;
        }
    }
}
