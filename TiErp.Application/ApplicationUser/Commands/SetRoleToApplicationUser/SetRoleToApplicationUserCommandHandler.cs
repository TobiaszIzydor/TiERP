using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ApplicationUser.Commands.SetRoleToApplicationUser
{
    public class SetRoleToApplicationUserCommandHandler : IRequestHandler<SetRoleToApplicationUserCommand, bool>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SetRoleToApplicationUserCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(SetRoleToApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return false;
            }

            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return false;
            }

            var isInRole = await _userManager.IsInRoleAsync(user, request.RoleName);
            if (isInRole)
            {
                return true; // Użytkownik już ma tę rolę
            }

            await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            return result.Succeeded; // Zwróć wynik przypisania roli
        }
    }

}
