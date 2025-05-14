using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class LibraryResourceDto
    {
        public int ResourceID { get; set; }
        public string CourseID { get; set; }
        public string Title { get; set; }
        public string ResourceType { get; set; }
        public string Author { get; set; }
        public string URL { get; set; }
        public DateTime UploadDate { get; set; }
    }

    public class CreateLibraryResourceDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string ResourceType { get; set; } // 'Book', 'Video', 'Article', etc.

        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(255)]
        public string URL { get; set; }
    }

    public class UpdateLibraryResourceDto
    {
        [MaxLength(20)]
        public string? CourseID { get; set; }

        [MaxLength(255)]
        public string? Title { get; set; }

        [MaxLength(50)]
        public string? ResourceType { get; set; }

        [MaxLength(100)]
        public string? Author { get; set; }

        [MaxLength(255)]
        public string? URL { get; set; }
    }
}