using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace DIS_Journal.Models
{
    //This is DbContext class, which is required for the connection between the database and the application
    class DisDbContext : DbContext
    {
        //This collection referes to table 'users' (the name of the collection should be just like the name of the table which it refers to)
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //the connection string
            optionsBuilder.UseMySQL("server=bqa0euv4na39nvxw2o9w-mysql.services.clever-cloud.com;database=bqa0euv4na39nvxw2o9w;user=uvllsqwcceiys8wh;password=L3OZQwgPkyHILB6WkETs");
        }
    }
}
