// DTO/SubmissionDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class SubmissionDto
    {
        public int SubmissionID { get; set; }
        public int AssignmentID { get; set; }
        public string StudentID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string FilePath { get; set; }
        public decimal? Score { get; set; }
        public string Feedback { get; set; }
    }

    public class CreateSubmissionDto
    {
        [Required]
        public int AssignmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }

        public string FilePath { get; set; }

        public string Feedback { get; set; } // Added Feedback property here
    }

    public class UpdateSubmissionDto
    {
        public string FilePath { get; set; }
        public decimal? Score { get; set; }
        public string? Feedback { get; set; }
    }
}