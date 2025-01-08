using TiErp.Application.Employee.DTOs;
using TiErp.Application.Employee.Queries.GetAllLiders;
using TiErp.Application.ProductionLine.Commands.EditProductionLine;

namespace TiErp.MVC.Models
{
    public class EditProductionLineView
    {
        public IEnumerable<EmployeeDto> Liders { get; set; } = default!;
        public EditProductionLineCommand EditProductionLineCommand { get; set; } = default!;
    }
}
