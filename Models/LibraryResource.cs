using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class LibraryResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; } // Navigation property

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

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } = DateTime.Now.Date; // Default to current date
    }
}