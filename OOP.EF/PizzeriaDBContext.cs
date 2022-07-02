using Microsoft.EntityFrameworkCore;
using OOP.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EF
{
    public class PizzeriaDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public PizzeriaDBContext() { }
        public PizzeriaDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(e => e.id);
        }
    }
}
