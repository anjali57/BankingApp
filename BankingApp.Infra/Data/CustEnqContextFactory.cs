using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infra.Data
{
    public class CustEnqContextFactory : IDesignTimeDbContextFactory<CustEnqContext>
    {
        public CustEnqContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustEnqContext>();

            // 👇 Use the same connection string you want for development
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BankingAppDb;Trusted_Connection=True;");

            return new CustEnqContext(optionsBuilder.Options);
        }
    }
}
