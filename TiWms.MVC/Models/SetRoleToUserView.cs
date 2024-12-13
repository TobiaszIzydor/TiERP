using TiWms.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiWms.Application.ApplicationUser.DTOs;
using TiWms.Application.ApplicationUser.GetAllRoles;
using TiWms.Application.ApplicationUser.GetAllUsers;
using TiWms.Application.Employee.Queries.GetAllLiders;

namespace TiWms.MVC.Models
{
    public class SetRoleToUserView
    {
        public SetRoleToApplicationUserCommand SetRoleToApplicationUserCommand { get; set; }
        public IEnumerable<ApplicationUserDto> Users { get; set; }
        public IEnumerable<IdentityRoleDto> Roles { get; set; }
    }
}
