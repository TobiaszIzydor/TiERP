using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.ProductionItem.DTOs
{
    public class ProductionItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EAN11 { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string WareHouseLocationCode { get; set; } = default!;
        public ICollection<Domain.Entities.Product>? Product { get; set; } = default!;
        public string? CreatedById { get; set; }
        public Domain.Entities.ApplicationUser? CreatedBy { get; set; }
    }
}
