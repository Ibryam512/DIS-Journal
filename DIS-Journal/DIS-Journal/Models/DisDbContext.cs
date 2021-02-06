using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace DIS_Journal.Models
{
    class DisDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=bqa0euv4na39nvxw2o9w-mysql.services.clever-cloud.com;database=bqa0euv4na39nvxw2o9w;user=uvllsqwcceiys8wh;password=L3OZQwgPkyHILB6WkETs");
        }
    }
}
