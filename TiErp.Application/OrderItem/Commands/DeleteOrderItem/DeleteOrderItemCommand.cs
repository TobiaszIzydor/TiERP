using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.OrderItem.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteOrderItemCommand(int id)
        {
            Id = id;
        }
    }
}
