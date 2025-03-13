using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAll();
        Task<OrderItem> GetById(int id);
        Task Create(OrderItem orderItem);
        Task AssignToOrder(int orderId, int orderItemId);
        Task<IEnumerable<OrderItem>> GetByOrderId(int id);
        Task<IEnumerable<OrderItem>> GetForProductionLine(int id);
        Task Commit();
        Task DeleteById(int id);
        Task<int> GetCountOrderItemsForProductionLine(ProductionLine productionLine);
        Task<int> GetCountOrderItemsCompletedForProductionLine(ProductionLine productionLine);
        Task<int> GetCountOrderItemsForProductionLineInMonth(ProductionLine productionLine);
        Task<int> GetCountOrderItemsCompletedForProductionLineInMonth(ProductionLine productionLine);
        Task<int> GetCountOrdersOverduedForProductionLineTotal(ProductionLine productionLine);
        Task<int> GetCountOrderItemsInMonth();
        Task<int> GetCountOrderItemsCompletedInMonth();
        Task<int> GetCountOrderItemsCompleted();
        Task<int> GetCountOrderItems();
        Task<int> GetCountOrderItemsOverdued();
        Task<int> GetCountOrderItemsOrderedInMonth();
    }
}
