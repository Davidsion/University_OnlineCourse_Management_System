// Models/Announcement.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Announcement
    {
        // [Key]: Specifies this property as the primary key.
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]: Indicates auto-generation by the database.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnnouncementID { get; set; }

        // Foreign Key to the Courses table (nullable)
        [MaxLength(20)]
        public string CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; } // Navigation property

        // Foreign Key to the Instructors table (nullable)
        [MaxLength(20)]
        public string InstructorID { get; set; }
        // [ForeignKey("InstructorID")]
        // public Instructor Instructor { get; set; } // Navigation property (if Instructor model exists)

        // [Required]: Ensures the title cannot be empty.
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        // [Required]: Ensures the content cannot be empty.
        [Required]
        public string Content { get; set; }

        // [DataType(DataType.DateTime)]: Specifies the data type.
        // Database default will handle GETDATE().
        public DateTime PostDate { get; set; }
    }
}
