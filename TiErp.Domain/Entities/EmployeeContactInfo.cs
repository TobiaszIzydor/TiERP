using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Domain.Entities
{
    public class EmployeeContactInfo
    {
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string EmergencyPhone { get; set; } = default!;
        public int EmployeeId { get; set; } = default!;
        public Employee Employee { get; set; } = default!;
    }
}
