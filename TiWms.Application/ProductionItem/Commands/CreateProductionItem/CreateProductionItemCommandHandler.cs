using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser;
using TiWms.Domain.Entities;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionItem.Commands.CreateProductionItem
{
    public class CreateProductionItemCommandHandler : IRequestHandler<CreateProductionItemCommand, Unit>
    {
        private readonly IProductionItemRepository _productionItemRepository;

        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductionItemCommandHandler(IProductionItemRepository productionItemRepository, IMapper mapper, IUserContext userContext, IProductRepository productRepository)
        {
            _mapper = mapper;
            _userContext = userContext;
            _productionItemRepository = productionItemRepository;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(CreateProductionItemCommand request, CancellationToken cancellationToken)
        {
            var productionItem = _mapper.Map<Domain.Entities.ProductionItem>(request);
            if ((await _userContext.GetCurrentUserAsync()).Id != null)
            {
                productionItem.CreatedById = (await _userContext.GetCurrentUserAsync()).Id;
            }
            if(request.ProductId != 0)
            {
                var product = await _productRepository.GetById(request.ProductId);
            productionItem.Product.Add(product);
            }
            await _productionItemRepository.Create(productionItem);
            return Unit.Value;
        }
    }
}
