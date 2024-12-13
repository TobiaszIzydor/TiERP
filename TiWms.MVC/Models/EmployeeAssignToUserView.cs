using Microsoft.AspNetCore.Mvc;
using TiWms.Application.ApplicationUser.DTOs;
using TiWms.Application.Employee.Commands.SetEmployeeToUser;
using TiWms.Application.Employee.DTOs;

namespace TiWms.MVC.Models
{
    public class EmployeeAssignToUserView
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
        public IEnumerable<ApplicationUserDto> Users{ get; set; }

        [BindProperty]
        public string UserId { get; set; } = string.Empty;
        [BindProperty]
        public int EmployeeId { get; set; }

    }
}
