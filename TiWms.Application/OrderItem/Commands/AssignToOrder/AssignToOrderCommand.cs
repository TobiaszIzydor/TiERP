using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.OrderItem.Commands.AssignToOrder
{
    public class AssignToOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public AssignToOrderCommand(int orderId, int orderItemId)
        {
            OrderId = orderId;
            OrderItemId = orderItemId;
        }
    }
}
