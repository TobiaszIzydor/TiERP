using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionLine.DTOs;

namespace TiWms.Application.ProductionLine.Queries.GetProductionLineById
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
