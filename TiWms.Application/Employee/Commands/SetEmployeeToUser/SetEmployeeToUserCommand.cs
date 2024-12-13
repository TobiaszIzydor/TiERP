using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.Employee.Commands.SetEmployeeToUser
{
    public class SetEmployeeToUserCommand : IRequest<bool>
    {
        public int EmployeeId;
        public string UserId;
        public SetEmployeeToUserCommand()
        {

        }
        public SetEmployeeToUserCommand(int employeeId, string userId)
        {
            EmployeeId = employeeId;
            UserId = userId;
        }
    }
}
