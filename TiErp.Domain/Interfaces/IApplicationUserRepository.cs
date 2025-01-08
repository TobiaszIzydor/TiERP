using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        public Task<IEnumerable<ApplicationUser>> GetAll();
        public Task<ApplicationUser> GetById(string id);
        public Task Commit();
    }
}
