using BankingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILoanService _loanService;

        public ManagerController(ICustomerService customerService, ILoanService loanService)
        {
            _customerService = customerService;
            _loanService = loanService;
        }

        [HttpPut("approve-customer/{customerId}")]
        public async Task<IActionResult> ApproveCustomer(string customerId)
        {
            var result = await _customerService.ApproveCustomerAsync(customerId);
            if (!result) return NotFound();
            return Ok("Customer approved successfully");
        }

        [HttpPut("reject-customer/{customerId}")]
        public async Task<IActionResult> RejectCustomer(string customerId)
        {
            var result = await _customerService.RejectCustomerAsync(customerId);
            if (!result) return NotFound();
            return Ok("Customer rejected successfully");
        }

        [HttpPut("approve-loan/{loanId}")]
        public async Task<IActionResult> ApproveLoan(int loanId)
        {
            var result = await _loanService.ApproveLoanAsync(loanId);
            return result ? Ok("Loan approved") : NotFound("Loan not found");
        }

        [HttpPut("reject-loan/{loanId}")]
        public async Task<IActionResult> RejectLoan(int loanId)
        {
            var result = await _loanService.RejectLoanAsync(loanId);
            return result ? Ok("Loan rejected") : NotFound("Loan not found");
        }
    }
}
