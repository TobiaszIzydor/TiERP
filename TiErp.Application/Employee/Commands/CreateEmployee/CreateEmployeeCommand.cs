using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : EmployeeDto, IRequest<Unit>
    {

    }
}
