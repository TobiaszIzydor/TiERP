using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Application.Employee.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? HireDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? EmergencyPhone { get; set; }
        public int ProductionLineId { get; set; } = 0;
        public Domain.Entities.ProductionLine? ProductionLine { get; set; }
        public string? UserId { get; set; }
        public Domain.Entities.ApplicationUser? User { get; set; }
    }
}
