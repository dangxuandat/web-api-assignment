using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Seat
	{	
		[Key]
		[Required(ErrorMessage = "Id is not null")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(1)]
		public char Row { get; set; }
		
		[Range(1,20,ErrorMessage = "Numbers of seat in each row in range 1 to 20")]
		public int Number { get; set; }

		public Auditorium Auditorium { get; set; }
	}
}
