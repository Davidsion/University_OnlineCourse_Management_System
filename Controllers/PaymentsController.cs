// Controllers/PaymentsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private const decimal TotalFee = 5000;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _paymentService.CreatePaymentAsync(createPaymentDto))
            {
                var createdPayment = await _paymentService.GetPaymentByIdAsync(1);
                return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.PaymentID }, createdPayment);
            }
            else
            {
                return StatusCode(500, "Failed to create payment.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentDto updatePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _paymentService.UpdatePaymentAsync(id, updatePaymentDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (await _paymentService.DeletePaymentAsync(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("student/{studentId}/semester/{semesterId}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPaymentsByStudentAndSemester(string studentId, string semesterId)
        {
            var payments = await _paymentService.GetPaymentsByStudentAndSemesterAsync(studentId, semesterId);
            return Ok(payments);
        }

        [HttpGet("status/{studentId}/{semesterId}")]
        public async Task<ActionResult<object>> GetPaymentStatus(string studentId, string semesterId)
        {
            var (totalPaid, paymentStatus) = await _paymentService.GetPaymentStatusAsync(studentId, semesterId, TotalFee);
            return Ok(new
            {
                TotalPaid = totalPaid,
                PaymentStatus = paymentStatus,
                TotalFee
            });
        }
    }
}
