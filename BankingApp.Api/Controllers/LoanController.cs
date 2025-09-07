using BankingApp.Api.DTOs;
using BankingApp.Domain.Entities;
using BankingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("apply")]
        public async Task<ActionResult<LoanReadDto>> ApplyLoan(LoanCreateDto dto)
        {
            var loan = new Loan
            {
                CustomerId = dto.CustomerId,
                Amount = dto.Amount
            };

            var createdLoan = await _loanService.ApplyLoanAsync(loan);

            return Ok(new LoanReadDto
            {
                LoanId = createdLoan.LoanId,
                CustomerId = createdLoan.CustomerId,
                Amount = createdLoan.Amount,
                Status = createdLoan.Status,
                AppliedOn = createdLoan.AppliedOn
            });
        }

        [HttpGet("using-loanId/{id}")]
        public async Task<ActionResult<LoanReadDto>> GetLoanById(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            if (loan == null) return NotFound();

            return Ok(new LoanReadDto
            {
                LoanId = loan.LoanId,
                CustomerId = loan.CustomerId,
                Amount = loan.Amount,
                Status = loan.Status,
                AppliedOn = loan.AppliedOn
            });
        }

        [HttpGet("using-customerId/{customerId}")]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoansByCustomerId(string customerId)
        {
            var loans = await _loanService.GetLoansByCustomerIdAsync(customerId);
            if (loans == null) return NotFound();

            return Ok(loans.Select(l => new LoanReadDto
            {
                LoanId = l.LoanId,
                CustomerId = l.CustomerId,
                Amount = l.Amount,
                Status = l.Status,
                AppliedOn = l.AppliedOn
            }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetAllLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            return Ok(loans.Select(l => new LoanReadDto
            {
                LoanId = l.LoanId,
                CustomerId = l.CustomerId,
                Amount = l.Amount,
                Status = l.Status,
                AppliedOn = l.AppliedOn
            }));
        }
    }
}
