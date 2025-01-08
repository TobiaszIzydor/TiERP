using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionLine.DTOs;

namespace TiErp.Application.ProductionLine.Queries.GetProductionLineById
{
    public class GetProductionLineByIdQuery : IRequest<ProductionLineDto>
    {
        public GetProductionLineByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
