// DTO/AssignmentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class AssignmentDto
    {
        public int AssignmentID { get; set; }
        public string CourseID { get; set; }
        public string InstructorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int MaxScore { get; set; }
    }

    public class CreateAssignmentDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required]
        [MaxLength(20)]
        public string InstructorID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }

        [Required]
        public int MaxScore { get; set; }
    }

    public class UpdateAssignmentDto
    {
        [MaxLength(20)]
        public string? CourseID { get; set; }

        [MaxLength(20)]
        public string? InstructorID { get; set; }

        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DueDate { get; set; }

        public int? MaxScore { get; set; }
    }
}
