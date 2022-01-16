using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.DataTransferObject
{
    public class MovieToShowDTO
    {
		public string Title { get; set; }
		public string Director { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public long Duration { get; set; }
		public ICollection<Cast> Casts { get; set; }

		public ICollection<Category> Categories { get; set; }
	}
}
