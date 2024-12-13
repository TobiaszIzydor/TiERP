using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.ProductionLine.Commands.CreateProductionLine
{
    public class CreateProductionLineCommandHandler : IRequestHandler<CreateProductionLineCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly IUserContext _userContext;
        public CreateProductionLineCommandHandler(IMapper mapper, IUserContext userContext, IProductionLineRepository productionLineRepository)
        {
            _userContext = userContext;
            _mapper = mapper;
            _productionLineRepository = productionLineRepository;
        }
        public async Task<Unit> Handle(CreateProductionLineCommand request, CancellationToken cancellationToken)
        {
            var productionLine = _mapper.Map<Domain.Entities.ProductionLine>(request);
            if ((await _userContext.GetCurrentUserAsync()).Id != null)
            {
                productionLine.CreatedById = (await _userContext.GetCurrentUserAsync()).Id;
            }
            await _productionLineRepository.Create(productionLine);
            return Unit.Value;
        }
    }
}
