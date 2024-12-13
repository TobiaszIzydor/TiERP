using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;
using TiWms.Domain.Interfaces;
using TiWms.Infrastructure.Persistence;

namespace TiWms.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly TiWmsDbContext _dbContext;
        public ApplicationUserRepository(TiWmsDbContext dbContext)
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
