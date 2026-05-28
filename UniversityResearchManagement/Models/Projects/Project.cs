using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using UniversityResearchManagement.Models.Faculties;

namespace UniversityResearchManagement.Models.Projects
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        [Column("end_date")]
        public DateOnly EndDate { get; set; }

        [Required]
        [Column("status")]
        public ProjectStatus Status { get; set; } = ProjectStatus.Pending;

        [Column("faculty_id")]
        public int? FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public Faculty? Faculty { get; set; }

        public enum ProjectStatus
        {
            Pending,
            InProgress,
            Completed,
            Cancelled
        }
    }
}