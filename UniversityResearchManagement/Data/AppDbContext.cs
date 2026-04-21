using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using UniversityResearchManagement.Models;
using UniversityResearchManagement.Models.Faculties;
using UniversityResearchManagement.Models.ProjectMembers;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u=>u.Role)
                .HasConversion<string>();


            modelBuilder.Entity<Project>()
                .Property(p => p.Status)
                .HasConversion(
                    v => v.ToString(),                         
                    v => (Status)Enum.Parse(typeof(Status), v) 
                );
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectMember> ProjectMembers { get; set; }
    }
}
