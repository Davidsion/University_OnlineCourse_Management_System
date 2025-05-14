// Models/Exam.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; } // Navigation property

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
}
