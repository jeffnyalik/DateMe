using DatingAPI.Data.Seeder;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Data.DataContext
{
    public class DateApiContext : DbContext
    {
        public DateApiContext(DbContextOptions<DateApiContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ValueSeeder());
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<User>Users { get; set;} 
    }
}
