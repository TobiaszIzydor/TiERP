using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.ApplicationUser
{
    public interface IUserContext
    {
        Task<CurrentUser> GetCurrentUserAsync();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        public UserContext(IHttpContextAccessor httpContextAccessor, UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CurrentUser> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Użytkownik nie jest zalogowany");
            }
            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new InvalidOperationException("Użytkownik nie jest zalogowany");
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var userFromManager = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            /*var employeeIdClaim = user.Claims.FirstOrDefault(c => c.Type == "EmployeeId");*/
            var roles = user.Claims.Where(c=> c.Type == ClaimTypes.Role).Select(c => c.Value);

            /*int? employeeId = null;
            if (employeeIdClaim != null && int.TryParse(employeeIdClaim.Value, out var parsedEmployeeId))
            {
                employeeId = parsedEmployeeId;
            }*/
            int? employeeId = null;
            if(userFromManager.EmployeeId != 0)
            {
                employeeId = userFromManager.EmployeeId;
            }


            return new CurrentUser(id, email, employeeId, roles);

        }
    }
}
