using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<ProductionItem> ProductionItems { get; set; } = new List<ProductionItem>();
        public ProductionLine ProductionLine { get; set; } = default!;
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
    }
}
