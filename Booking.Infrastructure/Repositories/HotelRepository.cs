using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly MyContext _dbContext;
        public HotelRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Hotel> CreateHotelAsync(Hotel newHotel)
        {
            await _dbContext.Hotels.AddAsync(newHotel);
            await _dbContext.SaveChangesAsync();
            return newHotel;
        }

        public async Task DeleteHotelAsync(int idHotel)
        {
            var existing = await _dbContext.Hotels.FindAsync(idHotel);
            _dbContext.Hotels.Remove(existing);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Hotel>> GetAllHotelsAsync() => await _dbContext.Hotels.ToListAsync();


        public async Task<Hotel> GetHotelByIdAsync(int idHotel) => await _dbContext.Hotels.FindAsync(idHotel);

        public async Task UpdateHotelAsync(int idHotel, Hotel updatedHotel)
        {
            _dbContext.Hotels.Update(updatedHotel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
