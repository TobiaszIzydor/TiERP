using TiWms.Application.Employee.DTOs;
using TiWms.Application.Employee.Queries.GetAllLiders;
using TiWms.Application.ProductionLine.Commands.EditProductionLine;

namespace TiWms.MVC.Models
{
    public class EditProductionLineView
    {
        public IEnumerable<EmployeeDto> Liders { get; set; } = default!;
        public EditProductionLineCommand EditProductionLineCommand { get; set; } = default!;
    }
}
