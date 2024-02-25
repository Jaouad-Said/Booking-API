using Booking.Domain.Models;
using Booking.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly MyContext _dbContext;

        public RoomController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return Ok(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            var old = await _dbContext.Rooms.FindAsync(id);
            if (old == null)
            {
                return NotFound();
            }

            old.Number = room.Number;
            old.NeedsRepair = room.NeedsRepair;
            old.HotelId = room.HotelId;

            _dbContext.Update(old);
            await _dbContext.SaveChangesAsync();

            return Ok(room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var existing = await _dbContext.Rooms.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _dbContext.Rooms.Remove(existing);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _dbContext.Rooms.ToListAsync();
            return Ok(rooms);
        }
    }
}
