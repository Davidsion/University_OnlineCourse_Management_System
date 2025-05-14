// Services/PaymentService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private const decimal TotalFee = 5000; // Define the total fee

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<bool> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            await _paymentRepository.AddAsync(payment);
            return await _paymentRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto)
        {
            var existingPayment = await _paymentRepository.GetByIdAsync(id);
            if (existingPayment == null)
            {
                return false;
            }

            _mapper.Map(updatePaymentDto, existingPayment);
            _paymentRepository.Update(existingPayment);
            return await _paymentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var paymentToDelete = await _paymentRepository.GetByIdAsync(id);
            if (paymentToDelete == null)
            {
                return false;
            }

            _paymentRepository.Delete(paymentToDelete);
            return await _paymentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByStudentAndSemesterAsync(string studentId, string semesterId)
        {
            var payments = await _paymentRepository.GetByStudentAndSemesterAsync(studentId, semesterId);
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<(decimal totalPaid, string paymentStatus)> GetPaymentStatusAsync(string studentId, string semesterId, decimal totalFee)
        {
            decimal totalPaid = await _paymentRepository.GetTotalPaidForStudentAndSemesterAsync(studentId, semesterId);
            string status;

            if (totalPaid >= totalFee)
            {
                status = "Completed";
            }
            else if (totalPaid > 0)
            {
                status = "Partial";
            }
            else
            {
                status = "Pending";
            }

            return (totalPaid, status);
        }
    }
}