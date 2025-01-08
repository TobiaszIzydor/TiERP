using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.ApplicationUser.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.ApplicationUser.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationUserRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            return dtos;
        }
    }
}
