using BankingApp.Domain.Entities;
using BankingApp.Domain.Repositories;
using BankingApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infra.Repo
{
    public class LoanRepo : ILoanRepo
    {
        private readonly CustEnqContext _context;

        public LoanRepo(CustEnqContext context)
        {
            _context = context;
        }

        public async Task<Loan> ApplyLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan?> GetLoanByIdAsync(int loanId)
        {
            return await _context.Loans.FindAsync(loanId);
        }

        public async Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(string customerId)
        {
            return await _context.Loans
                .Where(l => l.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<bool> UpdateLoanStatusAsync(int loanId, string status)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null) return false;

            loan.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
