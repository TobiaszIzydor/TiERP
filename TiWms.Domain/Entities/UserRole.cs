using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
