// DTO/TimetableDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class TimetableDto
    {
        public int TimetableID { get; set; }
        public string CourseID { get; set; }
        public string InstructorID { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string RoomNumber { get; set; }
    }

    public class CreateTimetableDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(20)]
        public string InstructorID { get; set; }

        [Required]
        [MaxLength(10)]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [MaxLength(20)]
        public string RoomNumber { get; set; }
    }

    public class UpdateTimetableDto
    {
        [MaxLength(20)]
        public string? CourseID { get; set; }

        [MaxLength(20)]
        public string? InstructorID { get; set; }

        [MaxLength(10)]
        public string? DayOfWeek { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        [MaxLength(20)]
        public string? RoomNumber { get; set; }
    }
}
