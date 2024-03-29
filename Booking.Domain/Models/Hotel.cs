﻿namespace Booking.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Stars { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
