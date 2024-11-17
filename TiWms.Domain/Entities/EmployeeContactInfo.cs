using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class EmployeeContactInfo
    {
        public required int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EmergencyPhone { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
