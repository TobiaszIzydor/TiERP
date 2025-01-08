using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ProductionItem.Commands.AssignProductionItemToProduct
{
    public class AssignProductionItemToProductCommand : IRequest<bool>
    {
        public int ProductionItemId {  get; set; }
        public int ProductId { get; set; }
        public AssignProductionItemToProductCommand(int productionItemId, int productId)
        {
            ProductionItemId = productionItemId;
            ProductId = productId;
        }
    }
}
