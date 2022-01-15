using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class SeatReservation
	{
		[Key]
		[Required(ErrorMessage = "Id is required")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public virtual ICollection<Reservation> Reservations { get; set; }

		public Seat Seat { get; set; }
	}
}
