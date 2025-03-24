using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;

namespace TiErp.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
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
