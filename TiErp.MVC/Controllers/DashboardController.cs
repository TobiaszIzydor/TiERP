using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiErp.Application.ApplicationUser;
using TiErp.Application.DashboardStats.GetDashboardStats;
using TiErp.Application.DashboardStats.GetDashboardStatsLider;
using TiErp.Application.Employee.Queries.GetEmployeeById;
using TiErp.Application.OrderItem.DTOs;
using TiErp.Application.OrderItem.Queries.GetAllOrderItems;
using TiErp.Application.OrderItem.Queries.GetOrderItemsForProductionLine;
using TiErp.MVC.Models;

namespace TiErp.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;

        public DashboardController(IUserContext userContext, IMediator mediator)
        {
            _mediator = mediator;
            _userContext = userContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            DashboardModel dashboardModel = new DashboardModel();
            if (User.IsInRole("Lider"))
            {
                var currentUser = await _userContext.GetCurrentUserAsync();
                if (currentUser.EmployeeId.HasValue)
                {
                    var employee = await _mediator.Send(new GetEmployeeByIdQuery(currentUser.EmployeeId.Value));
                    if (employee == null)
                    {
                        return NotFound("Pracownik nie został znaleziony.");
                    }
                    if (employee.ProductionLine.LineLiderId == employee.Id)
                    {
                        var prodLine = employee.LiderOfLine;
                        var dashboardStatsLider = await _mediator.Send(new GetDashboardStatsLiderQuery(prodLine));
                        var ordersForProdLine = await _mediator.Send(new GetOrderItemsForProductionLineQuery(prodLine.Id));
                        dashboardModel.CountOrdersForProductionLineTotal = dashboardStatsLider.CountOrdersForProductionLineTotal;
                        dashboardModel.CountOrdersCompletedForProductionLineTotal = dashboardStatsLider.CountOrdersCompletedForProductionLineTotal;
                        dashboardModel.CountOrdersForProductionLineInMonth = dashboardStatsLider.CountOrdersForProductionLineInMonth;
                        dashboardModel.CountOrdersCompletedForProductionLineInMonth = dashboardStatsLider.CountOrdersCompletedForProductionLineInMonth;
                        dashboardModel.CountOrdersOverduedForProductionLineTotal = dashboardStatsLider.CountOrdersOverduedForProductionLineTotal;
                        dashboardModel.OrdersForProductionLine = ordersForProdLine;

                        return View(dashboardModel);
                    }
                    else
                    {
                        return NotFound("Nie zostałeś przypisany jako lider do żadnej linii produkcyjnej.");
                    }
                    
                }
            }
            else if (User.IsInRole("Admin") || User.IsInRole("Kierownik"))
            {
                var dashboardStats = await _mediator.Send(new GetDashboardStatsQuery());
                var orders = await _mediator.Send(new GetAllOrderItemsQuery());
                dashboardModel.CountOrdersInMonth = dashboardStats.CountOrdersInMonth;
                dashboardModel.CountOrdersCompletedInMonth = dashboardStats.CountOrdersCompletedInMonth;
                dashboardModel.CountOrdersCompleted = dashboardStats.CountOrdersCompleted;
                dashboardModel.CountTotalOrders = dashboardStats.CountTotalOrders;
                dashboardModel.CountTotalOrdersItems = dashboardStats.CountTotalOrdersItems;
                dashboardModel.CountAllEmployees = dashboardStats.CountAllEmployees;
                dashboardModel.CountOverdueOrders = dashboardStats.CountOverdueOrders;
                dashboardModel.CountOrdersOrderedInMonth = dashboardStats.CountOrdersOrderedInMonth;
                dashboardModel.CountOrderItemsOrderedInMonth = dashboardStats.CountOrderItemsOrderedInMonth;
                dashboardModel.AllOrders = orders;
            }
            return View(dashboardModel);
        }
    }
}
