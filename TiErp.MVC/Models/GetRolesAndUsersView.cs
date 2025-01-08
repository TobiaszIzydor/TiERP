using TiErp.Application.ApplicationUser.DTOs;

namespace TiErp.MVC.Models
{
    public class GetRolesAndUsersView
    {
        public IEnumerable<ApplicationUserDto>? Users { get; set; }
        public IEnumerable<IdentityRoleDto>? Roles { get; set; }
    }
}
