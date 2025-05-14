// DTO/AttendanceDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class AttendanceDto
    {
        public int AttendanceID { get; set; }
        public int EnrollmentID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

    public class CreateAttendanceDto
    {
        [Required]
        public int EnrollmentID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // 'Present', 'Absent', 'Late'
    }

    public class UpdateAttendanceDto
    {
        public int? EnrollmentID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [MaxLength(20)]
        public string? Status { get; set; } // 'Present', 'Absent', 'Late'
    }
}
