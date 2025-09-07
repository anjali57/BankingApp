using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Entities
{
    public class Customer
    {
        public string CustomerId { get; set; } // PK
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsApproved { get; set; } = false;

        // Navigation
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
