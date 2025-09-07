using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Repositories
{
    public interface ICustomerRepo
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(string id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<bool> ApproveCustomerAsync(int id, bool isApproved);
    }
}
