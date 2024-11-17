using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    }
}
