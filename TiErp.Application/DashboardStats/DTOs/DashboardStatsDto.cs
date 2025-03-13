using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Order.DTOs;

namespace TiErp.Application.DashboardStats.DTOs
{
    public class DashboardStatsDto
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
    }
}
