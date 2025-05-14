// DTO/PaymentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public string StudentID { get; set; }
        public string SemesterID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionID { get; set; }
        public string Status { get; set; }
    }

    public class CreatePaymentDto
    {
        [Required]
        [MaxLength(50)]
        public string StudentID { get; set; }

        [Required]
        [MaxLength(15)]
        public string SemesterID { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")] // Add validation
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(100)]
        public string? TransactionID { get; set; } // Make TransactionID nullable

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // 'Completed', 'Pending', 'Failed'
    }

    public class UpdatePaymentDto
    {
        [MaxLength(50)]
        public string? StudentID { get; set; }

        [MaxLength(15)]
        public string? SemesterID { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal? Amount { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        [MaxLength(100)]
        public string? TransactionID { get; set; }

        [MaxLength(20)]
        public string? Status { get; set; }
    }
}
