using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademyApp.DataAccess.Data
{
    public class AcademyAppDbContext : DbContext
    {
        public AcademyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
