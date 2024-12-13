using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        public Task<IEnumerable<ApplicationUser>> GetAll();
        public Task<ApplicationUser> GetById(string id);
        public Task Commit();
    }
}
