using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class ShowtimesAuditorium
    {
        public Guid ShowtimesId { get; set; }
        public Showtimes Showtimes { get; set; }
        public Guid AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }
    }
}
