using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;

namespace TiErp.Application.Order.Commands.EditOrder
{
    public class EditOrderCommand : OrderDto, IRequest<Unit>
    {
    }
}
