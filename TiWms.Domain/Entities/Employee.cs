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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeContactInfo ContactInfo { get; set; }
        public EmployeePayroll Payroll { get; set; }
        public User User { get; set; }

    }
}
