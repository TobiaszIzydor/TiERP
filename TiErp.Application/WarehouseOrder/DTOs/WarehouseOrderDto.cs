using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Application.WarehouseOrder.DTOs
{
    public class WarehouseOrderDto
    {
        public int Id { get; set; }
        public ICollection<WarehouseOrderItem> Items { get; set; } = new List<WarehouseOrderItem>();
        public int DeliveryToLineId { get; set; }
        public Domain.Entities.ProductionLine DeliveryToLine { get; set; } = default!;
        public Status Status { get; set; }
    }
}
