using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Order.DTOs;

namespace TiWms.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderDto, IRequest<Unit>
    {
        public Domain.Entities.Order Order { get; set; }
        public CreateOrderCommand(Domain.Entities.Order order)
        {
            Order = order;
        }
        public CreateOrderCommand()
        {
            
        }
    }
}
