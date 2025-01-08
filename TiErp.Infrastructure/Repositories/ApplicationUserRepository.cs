using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;
using TiErp.Domain.Interfaces;
using TiErp.Infrastructure.Persistence;

namespace TiErp.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly TiErpDbContext _dbContext;
        public ApplicationUserRepository(TiErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var user = await _dbContext.Users.FirstAsync(x => x.Id == id);
            return user;
        }
    }
}
