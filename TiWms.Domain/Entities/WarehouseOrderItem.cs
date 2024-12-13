using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class WarehouseOrderItem
    {
        public int Id { get; set; }
        public ProductionItem ProductionItem { get; set; } = default!;
        public int Quantity { get; set; }

    }
}
