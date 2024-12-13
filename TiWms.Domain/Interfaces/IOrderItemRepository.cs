using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Domain.Interfaces
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
    }
}
