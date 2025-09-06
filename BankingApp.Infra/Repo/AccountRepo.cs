using BankingApp.Domain.Entities;
using BankingApp.Domain.Interfaces;
using BankingApp.Domain.Repositories;
using BankingApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Services.Repo
{
    public class AccountRepo : IAccountRepo
    {
        private readonly CustEnqContext _context;

        public AccountRepo(CustEnqContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            var lastAccountNumber = await _context.Accounts
            .OrderByDescending(a => a.AccountNumber)
            .Select(a => a.AccountNumber)
            .FirstOrDefaultAsync();

            // If no accounts exist, start from 100001
            int newAccountNumber = (lastAccountNumber == 0) ? 100001 : lastAccountNumber + 1;

            account.AccountNumber = newAccountNumber;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account?> GetAccountByNumberAsync(int accountNumber)
        {
            return await _context.Accounts.FindAsync(accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<bool> DepositAsync(int accountNumber, decimal amount)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);
            if (account == null) return false;

            account.Balance += amount;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> WithdrawAsync(int accountNumber, decimal amount)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);
            if (account == null || account.Balance < amount) return false;

            account.Balance -= amount;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
