using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;

namespace TiWms.Application.ProductionItem.Queries.GetAllProductionItemsForProduct
{
    public class GetAllProductionItemsForProductQuery : IRequest<IEnumerable<ProductionItemDto>>
    {
        public int Id { get; set; }
        public GetAllProductionItemsForProductQuery(int id)
        {
            Id = id;
        }
    }
}
