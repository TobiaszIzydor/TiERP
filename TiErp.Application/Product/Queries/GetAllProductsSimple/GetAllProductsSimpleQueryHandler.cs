using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Product.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Product.Queries.GetAllProductsSimple
{
    public class GetAllProductsSimpleQueryHandler : IRequestHandler<GetAllProductsSimpleQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsSimpleQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsSimpleQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllSimply();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return dtos;
        }
    }
}
