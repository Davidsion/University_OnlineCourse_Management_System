// DTO/GradeDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class GradeDto
    {
        public int GradeID { get; set; }
        public int EnrollmentID { get; set; }
        public int? ExamID { get; set; }
        public int? AssignmentID { get; set; }
        public decimal Score { get; set; }
        public string GradeLetter { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateGradeDto
    {
        // [Required]: EnrollmentID is needed to associate the grade with a student's enrollment.
        [Required]
        public int EnrollmentID { get; set; }

        // ExamID is optional as the grade might be for an assignment.
        public int? ExamID { get; set; }

        // AssignmentID is optional as the grade might be for an exam.
        public int? AssignmentID { get; set; }

        // [Required]: The numerical score is a fundamental part of the grade.
        [Required]
        public decimal Score { get; set; }

        // [Required]: The letter grade is a common way to represent academic performance.
        [Required]
        [MaxLength(2)]
        public string GradeLetter { get; set; }

        // Remarks can provide additional context about the grade.
        [MaxLength(255)]
        public string Remarks { get; set; }
    }

    public class UpdateGradeDto
    {
        // EnrollmentID is usually not updated after the grade is initially recorded.
        public int? EnrollmentID { get; set; }
        public int? ExamID { get; set; }
        public int? AssignmentID { get; set; }
        public decimal? Score { get; set; }
        [MaxLength(2)]
        public string? GradeLetter { get; set; }
        [MaxLength(255)]
        public string? Remarks { get; set; }
    }
}
