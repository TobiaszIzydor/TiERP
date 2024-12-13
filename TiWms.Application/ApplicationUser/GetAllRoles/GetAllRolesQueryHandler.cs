using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.ApplicationUser.DTOs;

namespace TiWms.Application.ApplicationUser.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<IdentityRoleDto>>
    {
        public RoleManager<IdentityRole> _roleManager;
        public IMapper _mapper;
        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IdentityRoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var dtos = _mapper.Map<IEnumerable<IdentityRoleDto>>(roles);
            return dtos;
        }
    }
}
