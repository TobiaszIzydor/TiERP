using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Product.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.Product.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public EditProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = _mapper.Map<ProductDto>(request);
            var product = await _productRepository.GetById(updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.ProductionItems = updatedProduct.ProductionItems;
                product.ProductionLine = updatedProduct.ProductionLine;
                await _productRepository.Commit();
            }
            return Unit.Value;
        }
    }
}
