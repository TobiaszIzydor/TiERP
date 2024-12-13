using TiWms.Application.ApplicationUser.DTOs;

namespace TiWms.MVC.Models
{
    public class GetRolesAndUsersView
    {
        public IEnumerable<ApplicationUserDto>? Users { get; set; }
        public IEnumerable<IdentityRoleDto>? Roles { get; set; }
    }
}
