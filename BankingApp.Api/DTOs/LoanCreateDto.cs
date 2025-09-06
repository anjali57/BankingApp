namespace BankingApp.Api.DTOs
{
    public class LoanCreateDto
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
