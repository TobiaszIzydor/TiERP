using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser.DTOs;

namespace TiErp.Application.ApplicationUser.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {
    }
}
