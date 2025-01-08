using TiErp.Application.Product.Commands.CreateProduct;
using TiErp.Application.Product.Commands.EditProduct;
using TiErp.Application.ProductionItem.DTOs;
using TiErp.Application.ProductionLine.DTOs;

namespace TiErp.MVC.Models
{
    public class EditProductView
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int ProductionLineId { get; set; }
        public IEnumerable<ProductionLineDto> productionLines { get; set; }
        public EditProductCommand EditProductCommand { get; set; } = new EditProductCommand();
        public IEnumerable<ProductionItemDto> AvailableProductionItems { get; set; }
        public List<int> SelectedProductionItemIds { get; set; } = new List<int>();
    }
}
