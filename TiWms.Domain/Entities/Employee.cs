using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateOnly HireDate { get; set; } = default!;
        public EmployeeContactInfo ContactInfo { get; set; } = default!;
        public int? ProductionLineId { get; set; }
        public ProductionLine? ProductionLine { get; set; }
        public string? UserId {  get; set; }
        public ApplicationUser? User { get; set; }
        public ProductionLine? LiderOfLine { get; set; }

    }
}
