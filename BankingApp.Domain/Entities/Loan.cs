using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }   // Primary Key
        public string CustomerId { get; set; }  // Foreign Key (we will link to Customer later)
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending"; // Default status: Pending
        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;
    }
}
