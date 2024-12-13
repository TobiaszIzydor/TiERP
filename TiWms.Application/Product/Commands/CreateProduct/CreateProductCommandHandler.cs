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

namespace TiWms.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUserContext userContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            if ((await _userContext.GetCurrentUserAsync()).Id != null)
            {
                product.CreatedById = (await _userContext.GetCurrentUserAsync()).Id;
            }
            await _productRepository.Create(product);
            return Unit.Value;
        }
    }
}
