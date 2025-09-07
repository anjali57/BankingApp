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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            return await _customerRepo.CreateCustomerAsync(customer);
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return await _customerRepo.GetCustomerByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllCustomersAsync();
        }

        public async Task<bool> ApproveCustomerAsync(int id, bool isApproved)
        {
            return await _customerRepo.ApproveCustomerAsync(id, isApproved);
        }
    }
}
