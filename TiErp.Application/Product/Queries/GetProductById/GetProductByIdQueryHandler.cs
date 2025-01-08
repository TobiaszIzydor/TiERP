using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Product.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            var dto = _mapper.Map<ProductDto>(product);
            return dto;
        }
    }
}
