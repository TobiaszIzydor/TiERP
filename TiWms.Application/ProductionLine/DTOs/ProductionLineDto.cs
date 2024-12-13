using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Application.ProductionLine.DTOs
{
    public class ProductionLineDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = default!;
        public int? LineLiderId { get; set; }
        public Domain.Entities.ApplicationUser? LineLider { get; set; }
        public ICollection<Domain.Entities.Employee>? Employees { get; set; }
        public ICollection<Domain.Entities.Product>? SupportedProducts { get; set; }
        public ICollection<Domain.Entities.Order>? Orders { get; set; }
    }
}
