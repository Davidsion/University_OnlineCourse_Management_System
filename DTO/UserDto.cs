using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string UserType { get; set; }
        public string ReferenceID { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public required string UserType { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReferenceID { get; set; }
    }

    public class UpdateUserDto
    {
        [MaxLength(50)]
        public string? Username { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? Password { get; set; }

        [MaxLength(20)]
        public string? UserType { get; set; }

        [MaxLength(50)]
        public string? ReferenceID { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? IsActive { get; set; }
    }
}
