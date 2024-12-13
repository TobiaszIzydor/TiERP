using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class ProductionItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string EAN11 { get; set; } = default!;
        public int Quantity { get; set; }
        public string WareHouseLocationCode { get; set; } = default!;
        public ICollection<Product> Product { get; set; } = default!;
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }

    }
}
