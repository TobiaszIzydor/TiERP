using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Application.Product.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Domain.Entities.ProductionItem>? ProductionItems { get; set; }
        public Domain.Entities.ProductionLine ProductionLine { get; set; } = default!;
        public string? CreatedById { get; set; }
        public Domain.Entities.ApplicationUser? CreatedBy { get; set; }
    }
}
