using Luna.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Luna.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologys { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
