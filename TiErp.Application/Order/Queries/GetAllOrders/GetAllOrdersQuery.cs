using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;

namespace TiErp.Application.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}
