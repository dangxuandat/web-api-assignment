using Cinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Showtimes
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime StartTime { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime EndTime { get; set; }

		public virtual IList<MovieShowtimes> MovieShowtimes { get; set; }
		
		public virtual IList<ShowtimesAuditorium> ShowtimesAuditoriums { get; set; }
	
	}
}
