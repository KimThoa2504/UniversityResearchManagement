using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Models.ProjectMembers
{
    [Table("ProjectMembers")]
    public class ProjectMember
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

        [Column("masinhvien")]
        [MaxLength(50)]
        public string MaSinhVien { get; set; } = string.Empty;

        [Column("hovaten")]
        [MaxLength(255)]
        public string HoVaTen { get; set; } = string.Empty;

        [Required]
        [Column("role")]
        public MemberRole Role { get; set; } = MemberRole.Member;

        public enum MemberRole
        {
            Leader,
            Member,
            Supporter
        }
    }
}
