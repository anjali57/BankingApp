using BankingApp.Api.DTOs;
using BankingApp.Domain.Entities;
using BankingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            var created = await _customerService.CreateCustomerAsync(customer);

            return Ok(new CustomerReadDto
            {
                CustomerId = created.CustomerId,
                Name = created.Name,
                Email = created.Email,
                Phone = created.Phone,
                IsApproved = created.IsApproved
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomerById(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            return Ok(new CustomerReadDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                IsApproved = customer.IsApproved
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return Ok(customers.Select(c => new CustomerReadDto
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                IsApproved = c.IsApproved
            }));
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveCustomer(int id, CustomerApprovalDto dto)
        {
            var result = await _customerService.ApproveCustomerAsync(id, dto.IsApproved);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
