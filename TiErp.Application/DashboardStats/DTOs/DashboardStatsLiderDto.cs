using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.DashboardStats.DTOs
{
    public class DashboardStatsLiderDto
    {
        public int CountOrdersForProductionLineInMonth { get; set; }
        public int CountOrdersCompletedForProductionLineInMonth { get; set; }
        public int CountOrdersCompletedForProductionLineTotal { get; set; }
        public int CountOrdersForProductionLineTotal { get; set; }
        public int CountOrdersOverduedForProductionLineTotal { get; set; }
    }
}
