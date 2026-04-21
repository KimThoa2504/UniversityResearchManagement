using Microsoft.AspNetCore.Mvc;
using UniversityResearchManagement.Models.ProjectMembers;
using UniversityResearchManagement.Services.ProjectMembers;

namespace UniversityResearchManagement.Controllers.ProjectMembers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMemberController : ControllerBase
    {
        private readonly IProjectMembersService _service;

        public ProjectMemberController(IProjectMembersService service)
        {
            _service = service;
        }

        // ================= Group by project =================
        [HttpGet]
        public async Task<IActionResult> GetGroupedProjectMembers()
        {
            var members = await _service.GetProjectMembers();
            var grouped = members
                .Where(m => m.Project != null)
                .GroupBy(m => m.Project!.Name)
                .ToDictionary(
                   g => g.Key ?? "Unknown",
                    g => g.Select(m => new
                    {
                        masinhvien = m.MaSinhVien,
                        name = m.Name,
                        role = m.Role.ToString()
                    }).ToList()
                );
            return Ok(grouped);
        }

        // ================= GET BY PROJECT ID =================
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetByProjectId(long projectId)
        {
            var members = await _service.GetByProjectId(projectId);

            if (members == null || members.Count == 0)
                return NotFound();

            return Ok(members);
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<IActionResult> Create(ProjectMember member)
        {
            var result = await _service.AddProjectMember(member);
            return StatusCode(201, result);
        }

        // ================= UPDATE =================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ProjectMember member)
        {
            var result = await _service.UpdateProjectMember(id, member);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteProjectMember(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
