using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public string? CreatedById { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
    }
}
