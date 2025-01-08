using TiErp.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiErp.Application.ApplicationUser.DTOs;
using TiErp.Application.ApplicationUser.GetAllRoles;
using TiErp.Application.ApplicationUser.GetAllUsers;
using TiErp.Application.Employee.Queries.GetAllLiders;

namespace TiErp.MVC.Models
{
    public class SetRoleToUserView
    {
        public SetRoleToApplicationUserCommand SetRoleToApplicationUserCommand { get; set; }
        public IEnumerable<ApplicationUserDto> Users { get; set; }
        public IEnumerable<IdentityRoleDto> Roles { get; set; }
    }
}
