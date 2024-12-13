using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.OrderItem.DTOs;

namespace TiWms.Application.OrderItem.Queries.GetOrderItemsForProductionLine
{
    public class GetOrderItemsForProductionLineQuery : IRequest<IEnumerable<OrderItemDto>>
    {
        public int Id { get; set; }
        public GetOrderItemsForProductionLineQuery(int id)
        {
            Id = id;
        }
    }
}
