// Services/Interfaces/IPaymentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task<bool> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<bool> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto);
        Task<bool> DeletePaymentAsync(int id);

        // New service methods
        Task<IEnumerable<PaymentDto>> GetPaymentsByStudentAndSemesterAsync(string studentId, string semesterId);
        Task<(decimal totalPaid, string paymentStatus)> GetPaymentStatusAsync(string studentId, string semesterId, decimal totalFee);
    }
}
