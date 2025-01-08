using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ProductionLine.Commands.DeleteProductionLine
{
    public class DeleteProductionLineCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteProductionLineCommand(int id)
        {
            Id = id;
        }
    }
}
