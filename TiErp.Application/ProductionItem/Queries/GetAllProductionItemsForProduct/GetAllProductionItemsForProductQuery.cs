using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionItem.DTOs;

namespace TiErp.Application.ProductionItem.Queries.GetAllProductionItemsForProduct
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
