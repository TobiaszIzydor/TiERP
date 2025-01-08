using TiErp.Application.Customer.DTOs;
using TiErp.Application.Product.DTOs;

namespace TiErp.MVC.Models
{
    public class OrderViewModel
    {
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
        public IEnumerable<ProductDto>? Products { get; set; }
        public IEnumerable<CustomerDto>? Customers { get; set; }
        public int CustomerId { get; set; }
        public DateOnly DeadLine { get; set; }
    }

    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
