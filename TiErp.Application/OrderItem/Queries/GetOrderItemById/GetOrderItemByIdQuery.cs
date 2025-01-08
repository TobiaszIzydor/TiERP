using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.OrderItem.DTOs;

namespace TiErp.Application.OrderItem.Queries.GetOrderItemById
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
