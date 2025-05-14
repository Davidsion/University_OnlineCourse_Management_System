// Models/Course.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Course
    {
        [Key]
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

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}
