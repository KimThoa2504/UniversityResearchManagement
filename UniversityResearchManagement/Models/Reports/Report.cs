using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityResearchManagement.Models.Reports
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("report_type")]
        public ReportType Type { get; set; }

        [Column("generated_at")]
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        [Column("description")]
        public string? Description { get; set; }

        public enum ReportType
        {
            Annual,
            Progress,
            Custom
        }
    }
}
