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
        public EmployeePayroll Payroll { get; set; } = default!;
        public User User { get; set; } = default!;

    }
}
