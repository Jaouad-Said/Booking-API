using Booking.Domain.Models;

namespace Booking.Domain.Abstractions.Repositories
{
    public interface IHotelRepository
    {
        public Task<Hotel> GetHotelByIdAsync(int idHotel);
        public Task<List<Hotel>> GetAllHotelsAsync();
        public Task<Hotel> CreateHotelAsync(Hotel newHotel);
        public Task UpdateHotelAsync(int idHotel, Hotel updatedHotel);
        public Task DeleteHotelAsync(int idHotel);
    }
}
