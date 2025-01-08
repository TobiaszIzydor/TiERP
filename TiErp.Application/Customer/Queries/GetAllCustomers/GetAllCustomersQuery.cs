using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.DTOs;

namespace TiErp.Application.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
    }
}
