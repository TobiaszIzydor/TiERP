using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TiErp.Domain.Entities
{
    public class ProductionLine
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int? LineLiderId { get; set; }
        public Employee? LineLider { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        [JsonIgnore]
        public ICollection<Product>? SupportedProducts { get; set; }
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
    }
}
