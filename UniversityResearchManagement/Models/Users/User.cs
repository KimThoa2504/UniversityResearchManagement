using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityResearchManagement.Models.Users
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("role")]
        public UserRole Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public enum UserRole
        {
            Admin,
            Lecturer
        }
    }
}
