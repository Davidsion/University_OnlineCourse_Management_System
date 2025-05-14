// Models/Timetable.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Timetable
    {
        // [Key]: Specifies this property as the primary key.
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]: Configures auto-generation by the database.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimetableID { get; set; }

        // [Required]: CourseID is mandatory for scheduling.
        // [MaxLength(20)]: Matches the CourseID column type in the database.
        // [ForeignKey("CourseID")]: Establishes the foreign key relationship with the Courses table.
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; } // Navigation property

        // [Required]: InstructorID is mandatory to know who is teaching.
        // [MaxLength(20)]: Matches the InstructorID column type in the database.
        // [ForeignKey("InstructorID")]: Establishes the foreign key relationship with the Instructors table.
        [Required]
        [MaxLength(20)]
        public string InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; } // Navigation property

        // [Required]: DayOfWeek is essential for the schedule.
        // [MaxLength(10)]: Limits the length of the day name (e.g., "Wednesday").
        [Required]
        [MaxLength(10)]
        public string DayOfWeek { get; set; }

        // [Required]: StartTime indicates when the class begins.
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        // [Required]: EndTime indicates when the class ends.
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        // [MaxLength(20)]: Specifies the maximum length for the RoomNumber (optional).
        [MaxLength(20)]
        public string RoomNumber { get; set; }
    }
}
