// Models/Enrollment.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // For auto-incrementing EnrollmentID
        public int EnrollmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; } // Navigation property to the Student

        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; } // Navigation property to the Course

        [Required]
        [MaxLength(15)]
        public string SemesterID { get; set; }

        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; } // Navigation property to the Semester (assuming you have a Semester model)

        public DateTime EnrollmentDate { get; set; } = DateTime.Now; // Default value as current date
    }
}