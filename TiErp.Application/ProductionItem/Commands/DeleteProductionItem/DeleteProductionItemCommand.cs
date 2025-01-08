using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ProductionItem.Commands.DeleteProductionItem
{
    public class DeleteProductionItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteProductionItemCommand(int id)
        {
            Id = id;
        }
    }
}
