using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IProductionItemRepository
    {
        Task Create(ProductionItem productionItem);
        Task <IEnumerable<ProductionItem>> GetAll();
        Task <IEnumerable<ProductionItem>> GetAllForProduct(int id);
        Task <ProductionItem> GetById(int id);
        Task DeleteById(int id);
        Task Commit();
    }
}
