using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using  System.ComponentModel.DataAnnotations.Schema;

namespace UniversityResearchManagement.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Column("FullName")]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }
        public enum UserRole
        {
            Admin,
            Lecturer,
            Student
        }

    }
}
