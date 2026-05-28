using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityResearchManagement.Models.EvaluationBoards;
using UniversityResearchManagement.Models.Users;

namespace UniversityResearchManagement.Models.BoardMembers
{
    [Table("BoardMembers")]
    public class BoardMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("board_id")]
        public int BoardId { get; set; }

        [ForeignKey("BoardId")]
        public EvaluationBoard Board { get; set; } = null!;

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        [Column("role")]
        public BoardMemberRole Role { get; set; } = BoardMemberRole.Member;

        public enum BoardMemberRole
        {
            Chairman,
            Secretary,
            Member
        }
    }
}
