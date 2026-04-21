using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using UniversityResearchManagement.Models.Faculties;

namespace UniversityResearchManagement.Models.Projects
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Column("start_date")]
        public DateTime? StartDay { get; set; }

        [Column("end_date")]
        public DateTime? EndDay { get; set; }

        [Required]
        public Status Status { get; set; }

        // ====== Foreign Key ======
        [Column("faculty_id")]
        public long? FacultyId { get; set; }

        // ====== Navigation Property ======
        [ForeignKey("FacultyId")]
        public virtual Faculties.Faculty? Faculty { get; set; }
    }

    public enum Status
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
}