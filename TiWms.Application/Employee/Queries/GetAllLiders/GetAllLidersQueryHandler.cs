using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Employee.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.Employee.Queries.GetAllLiders
{
    public class GetAllLidersQueryHandler : IRequestHandler<GetAllLidersQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllLidersQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllLidersQuery request, CancellationToken cancellationToken)
        {
            var liders = await _employeeRepository.GetLiders();
            var dtos = _mapper.Map<IEnumerable<EmployeeDto>>(liders);

            return dtos;
        }
    }
}
