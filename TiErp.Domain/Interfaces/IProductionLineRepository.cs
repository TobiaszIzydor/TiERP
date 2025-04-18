﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IProductionLineRepository
    {
        Task Create(ProductionLine productionLine);
        Task<IEnumerable<ProductionLine>> GetAll();
        Task<ProductionLine> GetById(int id);
        Task Update(ProductionLine productionLine);
        Task DeleteById(int id);
        Task Commit();
    }
}
