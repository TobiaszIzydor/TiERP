using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.Employee.Commands.SetEmployeeToUser
{
    public class SetEmployeeToUserCommandHandler : IRequestHandler<SetEmployeeToUserCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        public SetEmployeeToUserCommandHandler(IEmployeeRepository employeeRepository, IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(SetEmployeeToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserRepository.GetById(request.UserId);
            if(user == null)
            {
                return false;
            }
            var employee = await _employeeRepository.GetById(request.EmployeeId);
            if (employee == null)
            {
                return false;
            }
            user.EmployeeId = employee.Id;
            await _applicationUserRepository.Commit();
            return true;
        }
    }
}
