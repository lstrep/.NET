using Microsoft.EntityFrameworkCore;
using s20351Retake.EFConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20351;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConfectioneryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Confectionery_ClientOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientOrderEntityTypeConfiguration());
        }

    }
}
