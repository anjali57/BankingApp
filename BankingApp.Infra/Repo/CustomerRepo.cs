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
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustEnqContext _context;

        public CustomerRepo(CustEnqContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(c => c.Loans)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(c => c.Loans)
                .ToListAsync();
        }

        public async Task<bool> ApproveCustomerAsync(int id, bool isApproved)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            customer.IsApproved = isApproved;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
