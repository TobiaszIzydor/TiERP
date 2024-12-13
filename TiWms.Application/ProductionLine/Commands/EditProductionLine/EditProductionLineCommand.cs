using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionLine.DTOs;

namespace TiWms.Application.ProductionLine.Commands.EditProductionLine
{
    public class EditProductionLineCommand : ProductionLineDto, IRequest<Unit>
    {
    }
}
