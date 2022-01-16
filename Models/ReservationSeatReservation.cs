using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class ReservationSeatReservation
    {
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public Guid SeatReservationId { get; set; }
        public SeatReservation SeatReservation { get; set; }
    }
}
