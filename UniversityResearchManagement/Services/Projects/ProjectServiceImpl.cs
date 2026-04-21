using Microsoft.EntityFrameworkCore;
using UniversityResearchManagement.Data;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Services.Projects
{
    public class ProjectServiceImpl : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        // ================= GET ALL =================
        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects
                .Include(p => p.Faculty) 
                .ToListAsync();
        }

        // ================= CREATE =================
        public async Task<Project> AddProject(Project project)
        {
            //_context.Projects.Add(project);
            //await _context.SaveChangesAsync();
            //return project;
            Console.WriteLine("STATUS = " + project.Status);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        // ================= GET BY ID =================
        public async Task<Project?> GetProject(long id)
        {
            return await _context.Projects
                .Include(p => p.Faculty)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // ================= UPDATE =================
        public async Task<Project?> UpdateProject(long id, Project project)
        {
            var existing = await _context.Projects
                .Include(p => p.Faculty)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null)
                return null;

            existing.Name = project.Name;
            existing.Description = project.Description;
            existing.StartDay = project.StartDay;
            existing.EndDay = project.EndDay;
            existing.Status = project.Status;

            if (project.FacultyId != null)
            {
                existing.FacultyId = project.FacultyId;
            }

            await _context.SaveChangesAsync();
            return existing;
        }

        // ================= DELETE =================
        public async Task<bool> DeleteProject(long id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}   
