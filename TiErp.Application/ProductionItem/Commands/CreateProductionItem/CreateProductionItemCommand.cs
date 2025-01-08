using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ProductionItem.DTOs;

namespace TiErp.Application.ProductionItem.Commands.CreateProductionItem
{
    public class CreateProductionItemCommand : ProductionItemDto, IRequest<Unit>
    {
    }
}
