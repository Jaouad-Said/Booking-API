﻿namespace Booking.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool NeedsRepair { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
