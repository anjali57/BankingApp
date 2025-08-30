using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Repositories
{
    public interface IAccountRepo
    {
        Task<Account> CreateAccountAsync(Account account);
        Task<Account?> GetAccountByNumberAsync(int id);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<bool> DepositAsync(int accountNumber, decimal amount);
        Task<bool> WithdrawAsync(int accountNumber, decimal amount);
    }
}
