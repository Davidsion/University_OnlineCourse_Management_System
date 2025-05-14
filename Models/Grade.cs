// Models/Grade.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Grade
    {
        // [Key]: Specifies this property as the primary key for the Grade entity.
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]: Configures the database to auto-generate the primary key value.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeID { get; set; }

        // [Required]: Indicates that the EnrollmentID is a mandatory field.
        // [ForeignKey("EnrollmentID")]: Specifies the foreign key relationship with the Enrollments table.
        public int EnrollmentID { get; set; }
        [ForeignKey("EnrollmentID")]
        public Enrollment Enrollment { get; set; } // Navigation property to the related Enrollment.

        // [ForeignKey("ExamID")]: Specifies the foreign key relationship with the Exams table.
        // This allows a grade to be associated with a specific exam. It's nullable,
        // as a grade might be for an assignment, not an exam.
        public int? ExamID { get; set; }
        [ForeignKey("ExamID")]
        public Exam Exam { get; set; } // Navigation property to the related Exam.

        // [ForeignKey("AssignmentID")]: Specifies the foreign key relationship with the Assignments table.
        // This allows a grade to be associated with a specific assignment. It's nullable,
        // as a grade might be for an exam, not an assignment.
        public int? AssignmentID { get; set; }
        [ForeignKey("AssignmentID")]
        public Assignment Assignment { get; set; } // Navigation property to the related Assignment.

        // [Required]: Indicates that the Score is a mandatory field.
        // [Column(TypeName = "decimal(5, 2)")]: Specifies the precise data type for the Score in the database.
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Score { get; set; }

        // [Required]: Indicates that the GradeLetter is a mandatory field.
        // [MaxLength(2)]: Sets the maximum length for the GradeLetter (e.g., 'A', 'B+').
        [Required]
        [MaxLength(2)]
        public string GradeLetter { get; set; }

        // [MaxLength(255)]: Sets the maximum length for any optional Remarks.
        [MaxLength(255)]
        public string Remarks { get; set; }
    }
}

