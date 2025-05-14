// DTO/AnnouncementDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class AnnouncementDto
    {
        public int AnnouncementID { get; set; }
        public string CourseID { get; set; }
        public string InstructorID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }

    public class CreateAnnouncementDto
    {
        [MaxLength(20)]
        public string CourseID { get; set; }

        [MaxLength(20)]
        public string InstructorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class UpdateAnnouncementDto
    {
        [MaxLength(20)]
        public string? CourseID { get; set; }

        [MaxLength(20)]
        public string? InstructorID { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}