using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Infrastructure.Persistence;

namespace TiErp.Tests.Common
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly TiErpDbContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<TiErpDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Context = new TiErpDbContext(options);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
