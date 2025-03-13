using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.DashboardStats.DTOs;

namespace TiErp.Application.DashboardStats.GetDashboardStats
{
    public class GetDashboardStatsQuery : IRequest<DashboardStatsDto>
    {
    }
}
