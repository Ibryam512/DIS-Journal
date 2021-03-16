using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace DIS_Journal.Models
{
    //This is DbContext class, which is required for the connection between the database and the application
    class DisDbContext : DbContext
    {
        //This collections referes to the tables in the database (the name of the collection should be just like the name of the table which it refers to)
        public DbSet<User> Users { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //the string thanks to which there is connection between the database and the application
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
        }
    }
}
