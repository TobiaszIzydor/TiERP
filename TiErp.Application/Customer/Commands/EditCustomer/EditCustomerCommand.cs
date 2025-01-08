using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;

namespace TiErp.Application.Customer.Commands.EditCustomer
{
    public class EditCustomerCommand : CustomerDto, IRequest<Unit>
    {
    }
}
