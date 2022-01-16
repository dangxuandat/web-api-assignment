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
	public class Auditorium
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(15)]
		public string Name	{ get; set; }

		[Range(0,200)]
	    public int SeatNumbers { get; set; }

		public virtual IList<ShowtimesAuditorium> ShowtimesAuditoriums { get; set; }
	}
}
