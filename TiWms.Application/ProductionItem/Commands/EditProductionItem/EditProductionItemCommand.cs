using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ProductionItem.DTOs;

namespace TiWms.Application.ProductionItem.Commands.EditProductionItem
{
    public class EditProductionItemCommand : ProductionItemDto, IRequest<Unit>
    {
    }
}
