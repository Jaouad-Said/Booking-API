using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyContext _dbContext;

        public RoomRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> CreateHotelRoomAsync(Room newRoom)
        {
            await _dbContext.Rooms.AddAsync(newRoom);
            await _dbContext.SaveChangesAsync();

            return newRoom;
        }

        public async Task DeleteHotelRoomAsync(int idRoom)
        {
            var existing = await _dbContext.Rooms.FindAsync(idRoom);

            _dbContext.Rooms.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAllHoteRoomslAsync(int idHotel) =>
            await _dbContext.Rooms.Where(r => r.HotelId == idHotel).ToListAsync();

        public async Task<Room> GetHotelRoomByIdAsync(int idHotel, int idRoom) =>
            await _dbContext.Rooms.FirstOrDefaultAsync(r => r.HotelId == idHotel && r.Id == idRoom);


        public async Task UpdateHotelRoomAsync(int idHotel, Room updatedRoom)
        {
            updatedRoom.HotelId = idHotel;
            _dbContext.Rooms.Update(updatedRoom);
            await _dbContext.SaveChangesAsync();
        }
    }
}
