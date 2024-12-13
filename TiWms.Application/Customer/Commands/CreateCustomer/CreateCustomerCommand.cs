using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Customer.DTOs;
using TiWms.Application.Employee.DTOs;

namespace TiWms.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : CustomerDto, IRequest<Unit>
    {

    }
}
