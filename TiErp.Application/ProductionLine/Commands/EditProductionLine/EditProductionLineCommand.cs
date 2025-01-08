using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionLine.DTOs;

namespace TiErp.Application.ProductionLine.Commands.EditProductionLine
{
    public class EditProductionLineCommand : ProductionLineDto, IRequest<Unit>
    {
    }
}
