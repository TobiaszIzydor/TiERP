using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : CustomerDto, IRequest<Unit>
    {

    }
}
