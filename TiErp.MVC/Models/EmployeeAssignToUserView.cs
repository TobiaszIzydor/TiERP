using Microsoft.AspNetCore.Mvc;
using TiErp.Application.ApplicationUser.DTOs;
using TiErp.Application.Employee.Commands.SetEmployeeToUser;
using TiErp.Application.Employee.DTOs;

namespace TiErp.MVC.Models
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
