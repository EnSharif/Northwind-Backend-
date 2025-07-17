using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Concrete.EntityFramework
{
    public class NortwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Data Source=ENSHARIF;Initial Catalog=Northwind;Persist Security Info=True;User ID=EnjiSharif;Password=123456789;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> userOperationClaim { get; set; }
        public DbSet<OperationClaim> operationClaim { get; set; }


    }
}
