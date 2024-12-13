using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;

namespace TiWms.Application.ProductionItem.Queries.GetProductionItemByIdEntity
{
    public class GetProductionItemByIdEntityQuery : IRequest<Domain.Entities.ProductionItem>
    {
        public int Id { get; set; }
        public GetProductionItemByIdEntityQuery(int id)
        {
            Id = id;
        }
    }
}
