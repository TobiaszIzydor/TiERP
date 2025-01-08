using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order order);
        Task Commit();
        Task DeleteById(int id);
    }
}
