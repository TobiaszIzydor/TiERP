using TiWms.Application.Product.Commands.CreateProduct;
using TiWms.Application.ProductionItem.DTOs;
using TiWms.Application.ProductionLine.DTOs;

namespace TiWms.MVC.Models
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
