using Microsoft.AspNetCore.Mvc;
using UniversityResearchManagement.Data;
using UniversityResearchManagement.Models.Faculties;
using Microsoft.EntityFrameworkCore;

namespace UniversityResearchManagement.Controllers.Faculties
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacultiesController(AppDbContext context)
        {
            _context = context;
        }

        // ================= GET ALL =================
        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await _context.Faculties.ToListAsync();
            return Ok(faculties);
        }

        // ================= GET BY ID =================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaculty(long id)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty == null)
                return NotFound("Không tìm thấy khoa");

            return Ok(faculty);
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<IActionResult> CreateFaculty([FromBody] Models.Faculties.Faculty faculty)
        {
            try
            {
                _context.Faculties.Add(faculty);
                await _context.SaveChangesAsync();

                return StatusCode(201, "Tạo mới khoa thành công");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Tạo thất bại: " + e.Message);
            }
        }

        // ================= UPDATE =================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaculty(long id, [FromBody] Models.Faculties.Faculty faculty)
        {
            var existing = await _context.Faculties.FindAsync(id);

            if (existing == null)
                return NotFound($"Không tìm thấy khoa với ID: {id}");

            try
            {
                existing.Name = faculty.Name;
                existing.Description = faculty.Description;

                await _context.SaveChangesAsync();

                return Ok("Cập nhật thành công");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Lỗi cập nhật: " + e.Message);
            }
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(long id)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty == null)
                return NotFound("Không tìm thấy khoa");

            try
            {
                _context.Faculties.Remove(faculty);
                await _context.SaveChangesAsync();

                return Ok("Xóa thành công");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Xóa thất bại: " + e.Message);
            }
        }
    }
}