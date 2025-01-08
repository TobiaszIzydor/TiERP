using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
