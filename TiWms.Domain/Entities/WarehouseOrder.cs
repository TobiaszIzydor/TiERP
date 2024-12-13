using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class WarehouseOrder
    {
        public int Id { get; set; }
        public ICollection<WarehouseOrderItem> Items { get; set; } = new List<WarehouseOrderItem>();
        public ProductionLine DeliveryToLine { get; set; } = default!;
        public Status Status { get; set; }
    }
}
