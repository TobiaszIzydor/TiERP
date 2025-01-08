using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Product.DTOs;

namespace TiErp.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
