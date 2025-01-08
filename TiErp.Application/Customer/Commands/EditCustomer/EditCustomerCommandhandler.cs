using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Customer.Commands.EditCustomer
{
    public class EditCustomerCommandhandler : IRequestHandler<EditCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public EditCustomerCommandhandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var updatedCustomer =  _mapper.Map<CustomerDto>(request);
            var customer = await _customerRepository.GetById(updatedCustomer.Id);
            if (customer != null)
            {
                customer.Address = updatedCustomer.Address;
                customer.Phone = updatedCustomer.Phone;
                customer.Name = updatedCustomer.Name;
                await _customerRepository.Commit();
            }
            return Unit.Value;
        }
    }
}
