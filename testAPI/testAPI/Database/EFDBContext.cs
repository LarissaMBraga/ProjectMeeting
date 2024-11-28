using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using testAPI.Models;

namespace testAPI.Data
{
    public class EFDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDatabase");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Meet> Meet { get; set; }


    }

}
