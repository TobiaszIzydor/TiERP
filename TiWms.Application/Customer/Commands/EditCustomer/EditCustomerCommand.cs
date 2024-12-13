using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Customer.DTOs;

namespace TiWms.Application.Customer.Commands.EditCustomer
{
    public class EditCustomerCommand : CustomerDto, IRequest<Unit>
    {
    }
}
