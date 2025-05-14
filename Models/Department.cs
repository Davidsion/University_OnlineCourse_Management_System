// Models/Department.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.Models
{
    public class Department
    {
        [Key]
        [MaxLength(20)]
        public string DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string DepartmentName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string HOD { get; set; }
    }
}