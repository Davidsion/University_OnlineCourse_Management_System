// DTO/StudentDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class StudentDto
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string DepartmentID { get; set; }
        // We might not want to expose the raw image data in the base DTO
    }

    public class CreateStudentDto
    {
        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }

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

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string DepartmentID { get; set; }

        // Optionally include Image as a file upload mechanism in the API
        // For simplicity in DTO, we might handle image separately
    }

    public class UpdateStudentDto
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

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? DepartmentID { get; set; }

        // For updating image, we might have a separate endpoint or handle it differently
    }
}