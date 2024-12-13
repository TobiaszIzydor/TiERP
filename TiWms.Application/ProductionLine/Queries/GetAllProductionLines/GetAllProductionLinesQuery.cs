using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionLine.DTOs;

namespace TiWms.Application.ProductionLine.Queries.GetAllProductionLines
{
    public class GetAllProductionLinesQuery : IRequest<IEnumerable<ProductionLineDto>>
    {

    }
}
