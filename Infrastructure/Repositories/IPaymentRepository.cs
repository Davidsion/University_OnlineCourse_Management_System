// Infrastructure/Repositories/IPaymentRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
        Task<bool> SaveChangesAsync();

        // New methods to get payments by student and semester
        Task<IEnumerable<Payment>> GetByStudentAndSemesterAsync(string studentId, string semesterId);
        Task<decimal> GetTotalPaidForStudentAndSemesterAsync(string studentId, string semesterId);
    }
}