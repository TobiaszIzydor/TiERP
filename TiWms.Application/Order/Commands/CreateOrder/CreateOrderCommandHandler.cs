using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        private readonly ICustomerRepository _customerRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUserContext userContext, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userContext = userContext;
            _customerRepository = customerRepository;
        }
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.Order != null)
            {
                var order = _mapper.Map<Domain.Entities.Order>(request.Order);
                order.CreatedById = (await _userContext.GetCurrentUserAsync()).Id;
                order.Customer = await _customerRepository.GetById(order.CustomerId);
                await _orderRepository.Create(order);
                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}
