using Microsoft.EntityFrameworkCore;
using UniversityResearchManagement.Models.BoardMembers;
using UniversityResearchManagement.Models.Documents;
using UniversityResearchManagement.Models.EvaluationBoards;
using UniversityResearchManagement.Models.Evaluations;
using UniversityResearchManagement.Models.Faculties;
using UniversityResearchManagement.Models.ProjectMembers;
using UniversityResearchManagement.Models.Projects;
using UniversityResearchManagement.Models.Reports;
using UniversityResearchManagement.Models.Users;

namespace UniversityResearchManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<EvaluationBoard> EvaluationBoards { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("AdminURM123"),
                    FullName = "Quản trị viên hệ thống",
                    Email = "adminURM@gmai.edu.vn",
                    Role = User.UserRole.Admin,
                    CreatedAt = DateTime.Now,
                }
                );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>() 
                .HasIndex(u => u.Password).IsUnique();
        }
    }
}