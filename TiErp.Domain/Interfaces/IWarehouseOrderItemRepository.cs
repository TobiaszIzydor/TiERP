using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IWarehouseOrderItemRepository
    {
        Task Create(WarehouseOrderItem warehouseOrderItem);
        Task<IEnumerable<WarehouseOrderItem>> GetAll();
        Task<WarehouseOrderItem> GetById(int id);
    }
}
