using Booking.Domain.Models;
using Booking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly MyContext _dbContext;

        public CustomerController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var old = await _dbContext.Customers.FindAsync(id);
            if (old == null)
            {
                return NotFound();
            }

            old.FullName = customer.FullName;
            old.Cin = customer.Cin;

            _dbContext.Customers.Update(old);
            await _dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existing = await _dbContext.Customers.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(existing);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}
