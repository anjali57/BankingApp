using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Repositories
{
    public interface ILoanRepo
    {
        Task<Loan> ApplyLoanAsync(Loan loan);
        Task<Loan?> GetLoanByIdAsync(int loanId);

        Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(string customerId);
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<bool> UpdateLoanStatusAsync(int loanId, string status);
    }
}
