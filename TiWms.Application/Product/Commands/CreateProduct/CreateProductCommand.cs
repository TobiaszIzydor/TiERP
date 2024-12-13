using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Product.DTOs;

namespace TiWms.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ProductDto, IRequest<Unit>
    {
    }
}
