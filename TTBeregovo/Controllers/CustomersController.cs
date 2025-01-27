using Microsoft.AspNetCore.Mvc;
using TTBeregovo.Services.Interfaces;

namespace TTBeregovo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdays([FromQuery] DateTime date)
        {
            var result = await _customerService.GetBirthdaysAsync(date);
            return Ok(result);
        }

        [HttpGet("recent-buyers")]
        public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
        {
            var result = await _customerService.GetRecentBuyersAsync(days);
            return Ok(result);
        }

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCustomerCategories(int id)
        {
            var result = await _customerService.GetCustomerCategoriesAsync(id);
            return Ok(result);
        }
    }
}
