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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            return await _accountRepo.CreateAccountAsync(account);
        }

        public async Task<Account?> GetAccountByNumberAsync(int accountNumber)
        {
            return await _accountRepo.GetAccountByNumberAsync(accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepo.GetAllAccountsAsync();
        }

        public async Task<bool> DepositAsync(int accountNumber, decimal amount)
        {
            return await _accountRepo.DepositAsync(accountNumber, amount);
        }

        public async Task<bool> WithdrawAsync(int accountNumber, decimal amount)
        {
            return await _accountRepo.WithdrawAsync(accountNumber, amount);
        }
    }
}
