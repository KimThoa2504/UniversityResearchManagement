using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Services.Projects
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjects();
        Task<Project?> GetProject(long id);
        Task<Project> AddProject(Project project);
        Task<Project?> UpdateProject(long id, Project project);
        Task<bool> DeleteProject(long id);
    }
}
