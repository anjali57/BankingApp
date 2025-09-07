using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }   // PK
        public int AccountNumber { get; set; }   // FK → Account
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // "Deposit" / "Withdraw"
        public DateTime Date { get; set; }

        // Navigation
        public Account Account { get; set; }
    }
}
