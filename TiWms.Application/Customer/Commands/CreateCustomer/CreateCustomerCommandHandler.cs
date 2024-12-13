﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser;
using TiWms.Application.Employee.Commands.CreateEmployee;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUserContext userContext)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(request);
            if((await _userContext.GetCurrentUserAsync()).Id != null)
            {
                customer.CreatedById = (await _userContext.GetCurrentUserAsync()).Id;
            }
            await _customerRepository.Create(customer);
            return Unit.Value;
        }
    }
}