﻿using Cinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Reservation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		
		public  Account Account { get; set; }

		public  Showtimes Showtimes { get; set; }

		public virtual IList<ReservationSeatReservation> ReservationSeatReservations { get; set; }

		
	}
}
