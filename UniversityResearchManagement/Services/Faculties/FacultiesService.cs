using UniversityResearchManagement.Models;
using UniversityResearchManagement.Models.Faculties;

namespace UniversityResearchManagement.Services.Faculties
{
    public interface FacultiesService
    {
        Task<List<Faculty>> GetFaculties();
        Task<Faculty?> GetFaculty(long id);
        Task<Faculty> AddFaculty(Faculty faculty);
        Task<Faculty?> UpdateFaculty(long id, Faculty faculty);
        Task<bool> DeleteFaculty(long id);
    }
}
