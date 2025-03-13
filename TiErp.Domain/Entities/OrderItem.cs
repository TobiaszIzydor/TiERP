using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Domain.Entities
{
    public enum Status
    {
        ToDo,
        InProgress,
        Done,
        Canceled
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int? OrderId {  get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
        public int Made {  get; set; }
        public Status Status { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
