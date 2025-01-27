using Microsoft.AspNetCore.Mvc;
using TTBeregovo.Models.Entity;
using TTBeregovo.Services;

namespace TTBeregovo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchases()
        {
            var purchases = await _purchaseService.GetAllPurchasesAsync();
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            if (purchase == null) return NotFound();
            return Ok(purchase);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase(Purchase purchase)
        {
            await _purchaseService.AddPurchaseAsync(purchase);
            return CreatedAtAction(nameof(GetPurchaseById), new { id = purchase.Id }, purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id) return BadRequest();
            await _purchaseService.UpdatePurchaseAsync(purchase);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await _purchaseService.DeletePurchaseAsync(id);
            return NoContent();
        }
    }
}
