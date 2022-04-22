using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolRentalManagement.Models.Business;
using ToolRentalManagement.Models;
using ToolRentalManagement.Models.OrderId;
using ToolRentalManagement.Models;
using ToolRentalManagement.Models.User;

namespace ToolRentalManagement.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderId> OrderIds { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server = localhost\\sqlexpress; database = ToolRentalManagementDb; trusted_connection = true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.UserName })
                .IsUnique(true);
            modelBuilder.Entity<Tool>()
                .HasIndex(t => new { t.ItemCode })
                .IsUnique(true);
        }


    }
}