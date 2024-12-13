using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Commands.AssignProductionItemToProduct
{
    public class AssignProductionItemToProductCommandHandler : IRequestHandler<AssignProductionItemToProductCommand, bool>
    {
        private readonly IProductionItemRepository _productionItemRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public AssignProductionItemToProductCommandHandler(IProductionItemRepository productionItemRepository, IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productionItemRepository = productionItemRepository;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(AssignProductionItemToProductCommand request, CancellationToken cancellationToken)
        {
            if(request.ProductId == 0)
            {
                return false;
            }
            if (request.ProductionItemId == 0)
            {
                return false;
            }
            var productionItem = await _productionItemRepository.GetById(request.ProductionItemId);
            var product = await _productRepository.GetById(request.ProductId);
            productionItem.Product.Add(product);
            await _productionItemRepository.Commit();
            return true;
        }
    }
}
