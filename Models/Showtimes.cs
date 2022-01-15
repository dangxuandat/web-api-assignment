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
		[Required(ErrorMessage ="Id is not null")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime StartTime { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime EndTime { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
		
		public virtual ICollection<Auditorium> Auditoriums { get; set; }
	
	}
}
