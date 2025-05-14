// Models/Payment.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_OnlineCourse_Management_System.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; } // Navigation property

        [Required]
        [MaxLength(15)]
        public string SemesterID { get; set; }
        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; } // Navigation property

        [Required]
        [Column(TypeName = "decimal(10,2)")] // Use Column attribute for decimal precision
        public decimal Amount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(100)]
        public string TransactionID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // 'Completed', 'Pending', 'Failed'
    }
}
