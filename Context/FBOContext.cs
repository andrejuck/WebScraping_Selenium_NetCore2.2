using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScrapingRobot.Model;

namespace WebScrapingRobot.Context
{
    public class FBOContext : DbContext
    {

        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=FBODb;User Id=sa;Password=C@v4l0;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<AgencyOfficeLocation> AgencyOfficeLocations { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
    }
}
