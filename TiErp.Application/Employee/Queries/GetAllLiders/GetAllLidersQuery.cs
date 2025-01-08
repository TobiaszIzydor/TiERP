using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Employee.Queries.GetAllLiders
{
    public class GetAllLidersQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
