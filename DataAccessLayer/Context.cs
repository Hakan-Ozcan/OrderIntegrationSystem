using BusinessLayer.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context:DbContext
    {
        public Context()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TUMSAS0366;Database=AcceptOrderDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>().Property(b => b.MusteriSiparisNo).IsRequired();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<MaterialInformation> MaterialInformations { get; set; }
        public DbSet<OrderData> OrderDatas { get; set; }
        public DbSet<OrderStatus> OrderStatuss { get; set; }
    }
}
