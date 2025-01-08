using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Product.DTOs;

namespace TiErp.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ProductDto, IRequest<Unit>
    {
    }
}
