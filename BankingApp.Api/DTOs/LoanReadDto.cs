namespace BankingApp.Api.DTOs
{
    public class LoanReadDto
    {
        public int LoanId { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
