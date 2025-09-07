namespace BankingApp.Api.DTOs
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerReadDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsApproved { get; set; }
    }

    public class CustomerApprovalDto
    {
        public bool IsApproved { get; set; }
    }

}
