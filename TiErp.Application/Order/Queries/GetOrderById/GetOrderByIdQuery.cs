using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;

namespace TiErp.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
