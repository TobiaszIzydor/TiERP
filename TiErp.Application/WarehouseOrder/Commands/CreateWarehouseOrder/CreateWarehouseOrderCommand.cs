using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.WarehouseOrder.DTOs;

namespace TiErp.Application.WarehouseOrder.Commands.CreateWarehouseOrder
{
    public class CreateWarehouseOrderCommand : WarehouseOrderDto, IRequest<Unit>
    {
    }
}
