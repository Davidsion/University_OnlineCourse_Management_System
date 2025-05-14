// Models/Submission.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Submission
    {
        // [Key]: Specifies this property as the primary key.
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]: Indicates that the database will auto-generate the ID.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmissionID { get; set; }

        // [Required]: Ensures this foreign key cannot be null.
        // [ForeignKey("AssignmentID")]: Specifies the foreign key relationship with the Assignments table.
        public int AssignmentID { get; set; }
        [ForeignKey("AssignmentID")]
        public Assignment Assignment { get; set; } // Navigation property to the related Assignment.

        // [Required]: Ensures this foreign key cannot be null.
        // [MaxLength(50)]: Sets the maximum length for the StudentID.
        // [ForeignKey("StudentID")]: Specifies the foreign key relationship with the Students table (assuming you have a Students model).
        public string StudentID { get; set; }
        // [ForeignKey("StudentID")]
        // public Student Student { get; set; } // Navigation property to the related Student (if you have one).

        // [DataType(DataType.DateTime)]: Specifies the data type for date and time.
        // Database default value will be handled by the `DEFAULT GETDATE()` in the SQL.
        public DateTime SubmissionDate { get; set; }

        // [MaxLength(255)]: Sets the maximum length for the file path.
        public string FilePath { get; set; }

        // [Column(TypeName = "decimal(5, 2)")]: Specifies the exact data type and precision in the database.
        public decimal? Score { get; set; } // Nullable to allow for submissions that haven't been graded yet.

        // Allows for longer text feedback.
        public string Feedback { get; set; } = string.Empty;
    }
}
