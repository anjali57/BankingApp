using BankingApp.Domain.Entities;
using BankingApp.Domain.Interfaces;
using BankingApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Services
{

        public class LoanService : ILoanService
        {
            private readonly ILoanRepo _loanRepo;

        public LoanService(ILoanRepo loanRepo)
            {
                _loanRepo = loanRepo;
            }
        public Task<Loan> ApplyLoanAsync(Loan loan) => _loanRepo.ApplyLoanAsync(loan);
        public Task<Loan?> GetLoanByIdAsync(int loanId) => _loanRepo.GetLoanByIdAsync(loanId);

        public Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(string customerId) => _loanRepo.GetLoansByCustomerIdAsync(customerId);
        public Task<IEnumerable<Loan>> GetAllLoansAsync() => _loanRepo.GetAllLoansAsync();
        public Task<bool> UpdateLoanStatusAsync(int loanId, string status) => _loanRepo.UpdateLoanStatusAsync(loanId, status);
    }
}
