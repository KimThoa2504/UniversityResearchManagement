using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Models.ProjectMembers
{
    [Table("projectmembers")]
    public class ProjectMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("project_id")]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        [Column("masinhvien")]
        public string? MaSinhVien { get; set; }

        [Column("hovaten")]
        public string? Name { get; set; }

        [Required]
        public Role Role { get; set; }
    }
    public enum Role
    {
        Leader,
        Member,
        Supporter
    }
}
