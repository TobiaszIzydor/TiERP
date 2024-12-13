using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;

namespace TiWms.Application.OrderItem.Queries.GetOrderItemsByOrderId
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
