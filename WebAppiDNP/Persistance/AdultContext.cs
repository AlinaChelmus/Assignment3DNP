using Microsoft.EntityFrameworkCore;
using WebAppiDNP.Models;


namespace FileData
{
    public class AdultContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\alina\RiderProjects\Assignment3\Assignment3DNP\WebAppiDNP\Adults.db");
        }
    }
}