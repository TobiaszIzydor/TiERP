using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser;
using TiErp.Application.Employee.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly IUserContext _userContext;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, IUserContext userContext)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Domain.Entities.Employee>(request);
            employee.ProductionLineId = 1;
            await _employeeRepository.Create(employee);
            return Unit.Value;
        }
    }
}
