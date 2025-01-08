using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email, int? employeeId, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            EmployeeId = employeeId;
            Roles = roles;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public int? EmployeeId { get; set; }

        public IEnumerable<string> Roles { get; set; }
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
