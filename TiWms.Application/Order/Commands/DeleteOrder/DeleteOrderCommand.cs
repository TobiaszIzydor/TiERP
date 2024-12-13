using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id {  get; set; }
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
