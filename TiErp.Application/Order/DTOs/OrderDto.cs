using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Application.Order.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateOnly? DeadLine { get; set; }
        public Domain.Entities.Customer? Customer { get; set; }
        public int CustomerId {  get; set; }
        public ICollection<Domain.Entities.OrderItem>? Items { get; set; }
        public string? CreatedById { get; set; }
        public Domain.Entities.ApplicationUser? CreatedBy { get; set; }
    }
}
