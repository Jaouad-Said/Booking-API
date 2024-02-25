using Booking.Domain.Models;

namespace Booking.Domain.Abstractions.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> CreateHotelRoomAsync(int HotelId, Room newRoom);
        public Task UpdateHotelRoomAsync(int idHotel, Room updatedRoom);
        public Task DeleteHotelRoomAsync(int idRoom);
        public Task<List<Room>> GetAllHoteRoomslAsync(int idHotel);
        public Task<Room> GetHotelRoomByIdAsync(int idHotel, int idRoom);
    }
}
