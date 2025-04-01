using Autofac.Features.ResolveAnything;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(request.Id);
            if (customer != null)
            {
                if (customer.Orders?.Any() == true)
                {
                    throw new InvalidOperationException("The customer cannot be deleted because they have active orders.");
                }
                await _customerRepository.DeleteById(request.Id);
                return Unit.Value;
            }
            else
            {
                throw new ArgumentNullException(nameof(customer));
            }
        }
    }
}
