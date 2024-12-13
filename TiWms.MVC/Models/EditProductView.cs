using TiWms.Application.Product.Commands.CreateProduct;
using TiWms.Application.Product.Commands.EditProduct;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Application.ProductionLine.DTOs;

namespace TiWms.MVC.Models
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
