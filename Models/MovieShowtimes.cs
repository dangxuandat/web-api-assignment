using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class MovieShowtimes
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid ShowtimesId { get; set; }
        public Showtimes Showtimes { get; set; }
    }
}
