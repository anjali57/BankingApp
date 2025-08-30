using BankingApp.Domain.DTOs;
using BankingApp.Domain.Entities;
using BankingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST: api/accounts
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateDto accountCreateDto)
        {
            // Map DTO to entity
            var account = new Account
            {
                Name = accountCreateDto.Name,
                Balance = accountCreateDto.InitialBalance
            };

            // Call service
            var createdAccount = await _accountService.CreateAccountAsync(account);

            // Map entity back to read DTO
            var readDto = new AccountReadDto
            {
                AccountNumber = createdAccount.AccountNumber,
                Name = createdAccount.Name,
                Balance = createdAccount.Balance
            };

            return CreatedAtAction(nameof(GetAccountByNumber),
                new { accountNumber = createdAccount.AccountNumber }, readDto);
        }

        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<AccountReadDto>> GetAccountByNumber(int accountNumber)
        {
            var account = await _accountService.GetAccountByNumberAsync(accountNumber);
            if (account == null)
                return NotFound();

            return new AccountReadDto
            {
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance
            };
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // PUT: api/accounts/deposit/{id}
        [HttpPut("deposit/{accountNumber}")]
        public async Task<IActionResult> Deposit(int accountNumber, [FromQuery] decimal amount)
        {
            var success = await _accountService.DepositAsync(accountNumber, amount);
            if (!success) return BadRequest("Deposit failed.");
            return Ok("Deposit successful.");
        }

        // PUT: api/accounts/withdraw/{id}
        [HttpPut("withdraw/{id}")]
        public async Task<IActionResult> Withdraw(int accountNumber, [FromQuery] decimal amount)
        {
            var success = await _accountService.WithdrawAsync(accountNumber, amount);
            if (!success) return BadRequest("Withdrawal failed.");
            return Ok("Withdrawal successful.");
        }
    }
}
