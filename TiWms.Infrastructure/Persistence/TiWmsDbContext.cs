using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Infrastructure.Persistence
{
    public class TiWmsDbContext : DbContext
    {
        public TiWmsDbContext(DbContextOptions<TiWmsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.ContactInfo);
        }
    }

}
