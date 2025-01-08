using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;
using TiErp.Application.Employee.Queries.GetAllEmployees;
using TiErp.Application.Employee.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return dtos;
        }
    }
}
