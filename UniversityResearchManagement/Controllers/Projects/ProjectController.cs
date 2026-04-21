using Microsoft.AspNetCore.Mvc;
using UniversityResearchManagement.Models.Projects;
using UniversityResearchManagement.Services.ProjectMembers;
using UniversityResearchManagement.Services.Projects;


namespace UniversityResearchManagement.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMembersService _memberService;

        public ProjectController(
            IProjectService projectService,
            IProjectMembersService memberService)
        {
            _projectService = projectService;
            _memberService = memberService;
        }
        // ================= GET ALL =================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetProjects();
            return Ok(projects);
        }

        // ================= GET BY ID + MEMBERS =================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var project = await _projectService.GetProject(id);

            if (project == null)
                return NotFound();

            var members = await _memberService.GetByProjectId(id);

            var response = new
            {
                project = project,
                members = members
            };
            return Ok(response);
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            var result = await _projectService.AddProject(project);
            return StatusCode(201, result);
        }

        // ================= UPDATE =================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Project project)
        {
            var result = await _projectService.UpdateProject(id, project);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _projectService.DeleteProject(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
