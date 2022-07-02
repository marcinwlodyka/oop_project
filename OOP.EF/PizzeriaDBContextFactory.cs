using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EF
{
    public class PizzeriaDBContextFactory : IDesignTimeDbContextFactory<PizzeriaDBContext>
    {
        public PizzeriaDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<PizzeriaDBContext>();
            options.UseSqlServer("Server=DESKTOP-5CCMURE\\SQLCOURSE2017; Database=pizzeriaDB; Trusted_Connection=True");
            return new PizzeriaDBContext(options.Options);
        }
    }
}
