using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.DTOs
{
    public class AccountCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
    }
}
