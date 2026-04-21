using UniversityResearchManagement.Models.ProjectMembers;

namespace UniversityResearchManagement.Services.ProjectMembers
{
    public interface IProjectMembersService
    {
        Task<List<ProjectMember>> GetProjectMembers();
        Task<ProjectMember?> GetProjectMember(long id);
        Task<List<ProjectMember>> GetByProjectId(long projectId);
        Task<ProjectMember> AddProjectMember(ProjectMember member);
        Task<ProjectMember?> UpdateProjectMember(long id, ProjectMember member);
        Task<bool> DeleteProjectMember(long id);
    }
}
