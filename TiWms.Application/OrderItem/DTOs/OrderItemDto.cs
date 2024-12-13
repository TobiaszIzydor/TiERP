using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Application.OrderItem.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public Domain.Entities.Product? Product { get; set; } = default!;
        public int OrderId { get; set; }
        public Domain.Entities.Order? Order { get; set; }
        public int Quantity { get; set; }
        public int Made { get; set; }
        public Status Status { get; set; }
    }
}
