using InventoryBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly InventoryDBContext _context;

        public ItemsController(InventoryDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] InventoryItem item)
        {
            if (item == null)
            {
                return BadRequest("Invalid item data.");
            }

            try
            {
                // Add item to the database
                _context.InventoryItems.Add(item);
                await _context.SaveChangesAsync();

                // Return success response
                return CreatedAtAction(nameof(AddItem), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                // Return internal server error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
