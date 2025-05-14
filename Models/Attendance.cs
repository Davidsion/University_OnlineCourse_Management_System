// Models/Attendance.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceID { get; set; }

        [Required]
        public int EnrollmentID { get; set; }
        [ForeignKey("EnrollmentID")]
        public Enrollment Enrollment { get; set; } // Navigation property

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // 'Present', 'Absent', 'Late'
    }
}

