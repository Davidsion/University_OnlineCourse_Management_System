using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }

        [Required]
        [MaxLength(20)]
        public required string UserType { get; set; }

        [Required]
        [MaxLength(50)]
        public  string ReferenceID { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; } = true;
    }
}