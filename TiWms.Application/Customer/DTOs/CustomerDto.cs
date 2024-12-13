using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.Customer.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public string? CreatedById { get; set; }
        public Domain.Entities.ApplicationUser? CreatedBy { get; set; }
    }
}
