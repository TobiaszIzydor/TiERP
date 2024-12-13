using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;

namespace TiWms.Application.OrderItem.Queries.GetOrderItemById
{
    public class GetOrderItemByIdQuery : IRequest<OrderItemDto>
    {
        public int Id { get; set; }
        public GetOrderItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
