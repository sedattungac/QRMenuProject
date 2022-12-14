using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BUBEBSC; database=DbFood;integrated security=true");
            //optionsBuilder.UseSqlServer("Data Source=77.245.159.136;Initial Catalog=veteriner;User ID=veteriner;Password=A.sd12345678987654321;persist security info=True");
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
    }
}
