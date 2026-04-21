using UniversityResearchManagement.Data;
using UniversityResearchManagement.Models.ProjectMembers;
using Microsoft.EntityFrameworkCore;
namespace UniversityResearchManagement.Services.ProjectMembers
{
    public class ProjectMembersServiceImpl : IProjectMembersService
    {
        private readonly AppDbContext _context;

        public ProjectMembersServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        // ================= GET ALL =================
        public async Task<List<ProjectMember>> GetProjectMembers()
        {
            return await _context.ProjectMembers
                .Include(p => p.Project)
                .ToListAsync();
        }

        // ================= CREATE =================
        public async Task<ProjectMember> AddProjectMember(ProjectMember member)
        {
            _context.ProjectMembers.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        // ================= GET BY ID =================
        public async Task<ProjectMember?> GetProjectMember(long id)
        {
            return await _context.ProjectMembers
                .Include(p => p.Project)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // ================= GET BY PROJECT ID =================
        public async Task<List<ProjectMember>> GetByProjectId(long projectId)
        {
            return await _context.ProjectMembers
                .Where(p => p.ProjectId == projectId)
                .ToListAsync();
        }
        // ================= UPDATE =================
        public async Task<ProjectMember?> UpdateProjectMember(long id, ProjectMember member)
        {
            var existing = await _context.ProjectMembers.FindAsync(id);

            if (existing == null)
            {
                throw new Exception($"ProjectMember not found with id: {id}");
            }

            // update giống Java
            if (member.ProjectId != 0)
            {
                existing.ProjectId = member.ProjectId;
            }

            existing.MaSinhVien = member.MaSinhVien;
            existing.Name = member.Name;
            existing.Role = member.Role;

            await _context.SaveChangesAsync();
            return existing;
        }


        // ================= DELETE =================
        public async Task<bool> DeleteProjectMember(long id)
        {
            var member = await _context.ProjectMembers.FindAsync(id);

            if (member == null)
                return false;

            _context.ProjectMembers.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }

    }
    }
