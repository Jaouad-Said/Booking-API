using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
