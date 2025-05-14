// DTO/SemesterDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class SemesterDto
    {
        public string SemesterID { get; set; }
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateSemesterDto
    {
        [Required]
        [MaxLength(15)]
        public string SemesterID { get; set; }

        [Required]
        [MaxLength(50)]
        public string SemesterName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class UpdateSemesterDto
    {
        [MaxLength(50)]
        public string? SemesterName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}