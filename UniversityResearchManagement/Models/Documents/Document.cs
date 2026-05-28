using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Models.Documents
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [Column("file_name")]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        [Column("file_path")]
        public string FilePath { get; set; } = string.Empty;

        [Column("uploaded_at")]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

