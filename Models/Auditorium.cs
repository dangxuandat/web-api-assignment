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
		[Required(ErrorMessage = "Id is not null")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(15)]
		public string Name	{ get; set; }

		[Range(0,200)]
	    public int SeatNumbers { get; set; }

		public ICollection<Showtimes> Showtimes { get; set; }
	}
}
