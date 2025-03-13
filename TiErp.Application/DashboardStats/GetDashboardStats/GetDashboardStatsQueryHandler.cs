using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.DashboardStats.DTOs;
using TiErp.Domain.Interfaces;

namespace TiErp.Application.DashboardStats.GetDashboardStats
{
    public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, DashboardStatsDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderRepository _orderRepository;

        public GetDashboardStatsQueryHandler(IOrderItemRepository orderItemRepository, IEmployeeRepository employeeRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _employeeRepository = employeeRepository;
            _orderRepository = orderRepository;
        }
        public async Task<DashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
        {
            DashboardStatsDto dto = new DashboardStatsDto();
            dto.CountOrdersInMonth = await _orderItemRepository.GetCountOrderItemsInMonth();
            dto.CountOrdersCompletedInMonth = await _orderItemRepository.GetCountOrderItemsCompletedInMonth();
            dto.CountOrdersCompleted = await _orderItemRepository.GetCountOrderItemsCompleted();
            dto.CountTotalOrdersItems = await _orderItemRepository.GetCountOrderItems();
            dto.CountAllEmployees = await _employeeRepository.GetCountAllEmployees();
            dto.CountOverdueOrders = await _orderItemRepository.GetCountOrderItemsOverdued();
            dto.CountOrdersOrderedInMonth = await _orderRepository.GetCountOrderOrderedInMonth();
            dto.CountOrderItemsOrderedInMonth = await _orderItemRepository.GetCountOrderItemsOrderedInMonth();
            return dto;
        }
    }
}
