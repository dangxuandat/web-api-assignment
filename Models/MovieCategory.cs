using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class MovieCategory
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
