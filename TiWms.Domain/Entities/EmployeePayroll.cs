using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class EmployeePayroll
    {
        public int Id { get; set; }
        public decimal BaseSallary { get; set; }
        public decimal Bonus { get; set; }
        public DateOnly PayPeriodStart { get; set; }
        public DateOnly PayPeriodEnd { get; set; }
        public DateOnly PaymentDate { get; set; }
        public enum PaymentMethod
        {
            BankTransfer, 
            Cash 
        }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
