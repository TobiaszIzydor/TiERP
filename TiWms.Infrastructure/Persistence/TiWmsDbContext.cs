using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Infrastructure.Persistence
{
    public class TiWmsDbContext : IdentityDbContext<ApplicationUser>
    {

        public TiWmsDbContext(DbContextOptions<TiWmsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionItem> ProductionItems { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WarehouseOrder> WarehouseOrders { get; set; }
        public DbSet<WarehouseOrderItem> WarehouseOrdersItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.ContactInfo);
            modelBuilder.Entity<ProductionLine>()
                .HasOne(pl => pl.LineLider)
                .WithOne(e => e.LiderOfLine) // Każdy lider jest liderem jednej linii
                .HasForeignKey<ProductionLine>(pl => pl.LineLiderId) // Klucz obcy w ProductionLine
                .OnDelete(DeleteBehavior.Restrict); // Zapobiega kaskadowemu usuwaniu
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductionItems)
                .WithMany(pi => pi.Product)
                .UsingEntity(j => j.ToTable("ProductProductionItem"));
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<ApplicationUser>(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
