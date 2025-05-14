// DTO/ExamDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class ExamDto
    {
        public int ExamID { get; set; }
        public string CourseID { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }
    }

    public class CreateExamDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ExamName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExamDate { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public int TotalMarks { get; set; }
    }

    public class UpdateExamDto
    {
        [MaxLength(20)]
        public string? CourseID { get; set; }

        [MaxLength(100)]
        public string? ExamName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ExamDate { get; set; }

        public int? DurationMinutes { get; set; }

        public int? TotalMarks { get; set; }
    }
}

