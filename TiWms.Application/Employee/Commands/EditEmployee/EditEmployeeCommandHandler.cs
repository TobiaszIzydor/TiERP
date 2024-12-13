using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Employee.DTOs;
using TiWms.Domain.Interfaces;

namespace TiWms.Application.Employee.Commands.EditEmployee
{
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EditEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var updatedEmployee = _mapper.Map<EmployeeDto>(request);
            var employee = await _employeeRepository.GetById(updatedEmployee.Id);
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.HireDate = (DateOnly)updatedEmployee.HireDate;
                employee.ContactInfo.Phone = updatedEmployee.Phone;
                employee.ContactInfo.EmergencyPhone = updatedEmployee.EmergencyPhone;
                employee.ContactInfo.Email = updatedEmployee.Email;
                employee.ProductionLineId = updatedEmployee.ProductionLineId;
                _employeeRepository.Commit();
            }
            return Unit.Value;

        }
    }
}
