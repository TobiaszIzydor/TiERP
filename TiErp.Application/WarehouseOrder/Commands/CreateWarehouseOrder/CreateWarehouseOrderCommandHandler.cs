using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.WarehouseOrder.Commands.CreateWarehouseOrder
{
    public class CreateWarehouseOrderCommandHandler : IRequestHandler<CreateWarehouseOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseOrderRepository _warehouseOrderRepository;
        public Task<Unit> Handle(CreateWarehouseOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
