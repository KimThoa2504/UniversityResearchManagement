using System;
using System.Collections.Generic;
using UniversityResearchManagement.Data;
using UniversityResearchManagement.Models;
using UniversityResearchManagement.Models.Faculties;
using Microsoft.EntityFrameworkCore;

namespace UniversityResearchManagement.Services.Faculties
{
    public class FacultiesServiceImpl : FacultiesService
    {
        private readonly AppDbContext _context;
        public FacultiesServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        //------------------ GET ALL -----------------
        public async Task<List<Faculty>> GetFaculties()
        {
            return await _context.Faculties.ToListAsync();
        }

        //------------------- Create -----------------
        public async Task<Faculty> AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
            return faculty;
        }

        //------------------- GET BY ID -----------------
        public async Task<Faculty?> GetFaculty(long id)
        {
            return await _context.Faculties.FindAsync(id);
        }
        //------------------- UPDATE -----------------
        public async Task<Faculty?> UpdateFaculty(long id, Faculty faculty)
        {
            var existing = await _context.Faculties.FindAsync(id);
            if (existing == null)
                return null;

            existing.Name = faculty.Name;
            existing.Description = faculty.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        //------------------- DELETE -----------------
        public async Task<bool> DeleteFaculty(long id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
                return false;

            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
