// DTO/InstructorDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class InstructorDto
    {
        public string InstructorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string DepartmentID { get; set; }
    }

    public class CreateInstructorDto
    {
        [Required]
        [MaxLength(20)]
        public string InstructorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(20)]
        public string DepartmentID { get; set; }
    }

    public class UpdateInstructorDto
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(20)]
        public string? DepartmentID { get; set; }
    }
}