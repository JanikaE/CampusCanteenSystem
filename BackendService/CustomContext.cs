using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace BackendService
{
    public class CustomContext : DbContext 
    {
        public CustomContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}