using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public int? EmployeeId { get; set; }
        public string EmployeeCardPassword { get; set; } = PasswordGenerator.PasswordGenerator.GenerateUniquePassword();
        public Employee? Employee { get; set; }

    }
}
