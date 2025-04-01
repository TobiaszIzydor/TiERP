using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Order.Commands.CreateOrder
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
            if (request != null && request.Order != null)
            {
                var order = _mapper.Map<Domain.Entities.Order>(request.Order);
                var user = await _userContext.GetCurrentUserAsync(); // Upewnij się, że _userContext to mock
                if (user == null)
                {
                    throw new ArgumentException("The sender's user session could not be defined.");
                }
                foreach(var item in order.Items)
                {
                    if (item.Quantity <= 0)
                    {
                        throw new ArgumentException("The quantity cannot by lower than 1");
                    }
                }
                order.CreatedById = user.Id;
                order.Customer = await _customerRepository.GetById(order.CustomerId) ?? throw new ArgumentException(nameof(order.Customer));
                await _orderRepository.Create(order);
                return Unit.Value;
            }
            else if (request.Order == null)
            {
                throw new ArgumentNullException("Order cannot be empty.");
            }
            else
            {
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}
