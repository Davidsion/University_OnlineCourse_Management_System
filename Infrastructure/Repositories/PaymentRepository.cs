// Infrastructure/Repositories/PaymentRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Data;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public PaymentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
        }

        public void Update(Payment payment)
        {
            _dbContext.Entry(payment).State = EntityState.Modified;
        }

        public void Delete(Payment payment)
        {
            _dbContext.Payments.Remove(payment);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Payment>> GetByStudentAndSemesterAsync(string studentId, string semesterId)
        {
            return await _dbContext.Payments
                .Where(p => p.StudentID == studentId && p.SemesterID == semesterId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPaidForStudentAndSemesterAsync(string studentId, string semesterId)
        {
            return await _dbContext.Payments
                .Where(p => p.StudentID == studentId && p.SemesterID == semesterId)
                .SumAsync(p => p.Amount);
        }
    }
}
