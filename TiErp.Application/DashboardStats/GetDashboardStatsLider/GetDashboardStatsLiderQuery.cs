using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.DashboardStats.DTOs;

namespace TiErp.Application.DashboardStats.GetDashboardStatsLider
{
    public class GetDashboardStatsLiderQuery : IRequest<DashboardStatsLiderDto>
    {
        public Domain.Entities.ProductionLine ProductionLine;
        public GetDashboardStatsLiderQuery(Domain.Entities.ProductionLine productionLine)
        {
            ProductionLine = productionLine;
        }
    }
}
