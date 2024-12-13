using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Employee.DTOs;

namespace TiWms.Application.Employee.Commands.EditEmployee
{
    public class EditEmployeeCommand : EmployeeDto, IRequest<Unit>
    {
    }
}
