using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Application.ApplicationUser.Commands.SetRoleToApplicationUser
{
    public class SetRoleToApplicationUserCommand : IRequest<bool>
    {
        public string RoleName { get; set; }
        public string UserId { get; set; }

        // Konstruktor
        public SetRoleToApplicationUserCommand()
        {
            
        }
        public SetRoleToApplicationUserCommand(string roleName, string userId)
        {
            RoleName = roleName;
            UserId = userId;
        }
    }
}
