using Microsoft.EntityFrameworkCore;
using OOP.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EF
{
    public class PizzeriaDBContex : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public PizzeriaDBContex() { }
        public PizzeriaDBContex(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(e => e.id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5CCMURE\\SQLCOURSE2017; Database=pizzeriaDB; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
