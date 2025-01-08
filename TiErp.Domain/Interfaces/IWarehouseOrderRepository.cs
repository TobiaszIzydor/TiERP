using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IWarehouseOrderRepository
    {
        Task Create(WarehouseOrder warehouseOrder);
        Task<IEnumerable<WarehouseOrder>> GetAll();
        Task<WarehouseOrder> GetById(int id);
        Task Commit();
        Task Delete(int id);
    }
}
