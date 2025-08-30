using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(Account account);
        Task<Account?> GetAccountByNumberAsync(int accountNumber);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<bool> DepositAsync(int accountNumber, decimal amount);
        Task<bool> WithdrawAsync(int accountNumber, decimal amount);
    }

}
