// Models/Semester.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.Models
{
    public class Semester
    {
        [Key]
        [MaxLength(15)]
        public string SemesterID { get; set; }

        [Required]
        [MaxLength(50)]
        public required string SemesterName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
