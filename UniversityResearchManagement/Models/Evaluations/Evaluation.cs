using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityResearchManagement.Models.EvaluationBoards;
using UniversityResearchManagement.Models.Projects;

namespace UniversityResearchManagement.Models.Evaluations
{
    [Table("Evaluations")]
    public class Evaluation
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
        [Column("board_id")]
        public int BoardId { get; set; }

        [ForeignKey("BoardId")]
        public EvaluationBoard Board { get; set; } = null!;

        [Column("evaluation_date")]
        public DateOnly EvaluationDate { get; set; }

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("score")]
        public decimal Score { get; set; }
    }
}
