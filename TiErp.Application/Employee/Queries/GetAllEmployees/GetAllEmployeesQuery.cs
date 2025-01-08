using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {

    }
}
