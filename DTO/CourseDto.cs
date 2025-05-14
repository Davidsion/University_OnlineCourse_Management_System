// DTO/CourseDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class CourseDto
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int CreditHours { get; set; }
        public string DepartmentID { get; set; }
    }

    public class CreateCourseDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CourseCode { get; set; }

        [Required]
        public int CreditHours { get; set; }

        [Required]
        [MaxLength(20)]
        public string DepartmentID { get; set; }
    }

    public class UpdateCourseDto
    {
        [MaxLength(100)]
        public string? CourseName { get; set; }

        [MaxLength(10)]
        public string? CourseCode { get; set; }

        public int? CreditHours { get; set; }

        [MaxLength(20)]
        public string? DepartmentID { get; set; }
    }
}
