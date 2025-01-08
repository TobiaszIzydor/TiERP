using TiErp.Application.Product.Commands.CreateProduct;
using TiErp.Application.ProductionItem.DTOs;
using TiErp.Application.ProductionLine.DTOs;

namespace TiErp.MVC.Models
{
    public class CreateProductView
    {
        public string? Name { get; set; }
        public int ProductionLineId { get; set; }
        public IEnumerable<ProductionLineDto> productionLines { get; set; }
        public CreateProductCommand CreateProductCommand { get; set; } = new CreateProductCommand();
        public IEnumerable<ProductionItemDto> AvailableProductionItems { get; set; }
        public List<int> SelectedProductionItemIds { get; set; } = new List<int>();
    }
}
