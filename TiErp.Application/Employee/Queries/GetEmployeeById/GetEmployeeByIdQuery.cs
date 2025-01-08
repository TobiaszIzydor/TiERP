using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int EmployeeId { get; set; }
        public GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }

    }
}
