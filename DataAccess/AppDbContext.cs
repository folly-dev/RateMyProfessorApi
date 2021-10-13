
using Microsoft.EntityFrameworkCore;
using WebApiTutorials.EfModels;

namespace WebApiTutorials.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Suffix> Suffix { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
}