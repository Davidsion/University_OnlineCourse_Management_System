// DTO/DepartmentDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class DepartmentDto
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string HOD { get; set; }
    }

    public class CreateDepartmentDto
    {
        [Required]
        [MaxLength(20)]
        public string DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [Required]
        [MaxLength(100)]
        public string HOD { get; set; }
    }

    public class UpdateDepartmentDto
    {
        [MaxLength(100)]
        public string? DepartmentName { get; set; }

        [MaxLength(100)]
        public string? HOD { get; set; }
    }
}