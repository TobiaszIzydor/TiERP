using TiErp.Application.OrderItem.DTOs;

namespace TiErp.MVC.Models
{
    public class DashboardModel
    {
        public int CountOrdersInMonth { get; set; }
        public int CountOrdersCompletedInMonth { get; set; }
        public int CountOrdersCompleted { get; set; }
        public int CountTotalOrders { get; set; }
        public int CountTotalOrdersItems { get; set; }
        public int CountAllEmployees { get; set; }
        public int CountOverdueOrders { get; set; }
        public int CountOrdersOrderedInMonth { get; set; }
        public int CountOrderItemsOrderedInMonth { get; set; }
        public IEnumerable<OrderItemDto>? AllOrders { get; set; }

        //For production line lider
        public IEnumerable<OrderItemDto>? OrdersForProductionLine { get; set; }
        public int CountOrdersForProductionLineTotal { get; set; }
        public int CountOrdersCompletedForProductionLineTotal { get; set; }
        public int CountOrdersForProductionLineInMonth { get; set; }
        public int CountOrdersCompletedForProductionLineInMonth { get; set; }
        public int CountOrdersOverduedForProductionLineTotal { get; set; }

    }
}
