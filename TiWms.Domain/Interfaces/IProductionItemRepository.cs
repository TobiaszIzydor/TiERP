using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Domain.Interfaces
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
