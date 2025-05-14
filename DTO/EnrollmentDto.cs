// DTO/EnrollmentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class EnrollmentDto
    {
        public int EnrollmentID { get; set; }
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public string SemesterID { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public class CreateEnrollmentDto
    {
        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(15)]
        public string SemesterID { get; set; }

        // EnrollmentDate will default to the current date in the model,
        // so it's usually not required in the creation DTO.
    }

    public class UpdateEnrollmentDto
    {
        // Typically, you might not update the core identifiers of an enrollment.
        // However, if needed, you can include properties to update here.
        // For example:
        // public DateTime? EnrollmentDate { get; set; }
    }
}