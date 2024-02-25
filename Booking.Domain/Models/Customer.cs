using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Cin { get; set; }
    }
}
