using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public Hotel Hotel { get; set; }
        public int IdRoom { get; set; }
        public Room Room { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime ChecOut { get; set; }

    }
}
