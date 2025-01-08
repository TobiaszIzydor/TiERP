using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.Queries.GetAllEmployees;
using TiErp.Application.Employee.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetById(request.EmployeeId);
            var dtos = _mapper.Map<EmployeeDto>(employee);
            return dtos;
        }
    }
}
