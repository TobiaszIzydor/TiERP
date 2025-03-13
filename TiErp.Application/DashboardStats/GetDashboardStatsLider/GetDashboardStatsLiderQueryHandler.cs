using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.DashboardStats.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.DashboardStats.GetDashboardStatsLider
{
    public class GetDashboardStatsLiderQueryHandler : IRequestHandler<GetDashboardStatsLiderQuery, DashboardStatsLiderDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public GetDashboardStatsLiderQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<DashboardStatsLiderDto> Handle(GetDashboardStatsLiderQuery request, CancellationToken cancellationToken)
        {
            DashboardStatsLiderDto dto = new DashboardStatsLiderDto();
            dto.CountOrdersForProductionLineTotal = await _orderItemRepository.GetCountOrderItemsForProductionLine(request.ProductionLine);
            dto.CountOrdersCompletedForProductionLineTotal =  await _orderItemRepository.GetCountOrderItemsCompletedForProductionLine(request.ProductionLine);
            dto.CountOrdersForProductionLineInMonth = await _orderItemRepository.GetCountOrderItemsForProductionLineInMonth(request.ProductionLine);
            dto.CountOrdersCompletedForProductionLineInMonth = await _orderItemRepository.GetCountOrderItemsCompletedForProductionLineInMonth(request.ProductionLine);
            dto.CountOrdersOverduedForProductionLineTotal = await _orderItemRepository.GetCountOrdersOverduedForProductionLineTotal(request.ProductionLine);
            return dto;
        }
    }
}
