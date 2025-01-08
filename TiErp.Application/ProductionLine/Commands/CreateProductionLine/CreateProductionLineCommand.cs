using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionLine.DTOs;

namespace TiErp.Application.ProductionLine.Commands.CreateProductionLine
{
    public class CreateProductionLineCommand : ProductionLineDto , IRequest<Unit>
    {
    }
}
