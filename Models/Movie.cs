using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Movie
	{
		[Key]
		[Required(ErrorMessage = "Id is not null")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(256)]
		public string Title { get; set; }

		[StringLength(100)]
		public string Director { get; set; }

		[Column(TypeName = "ntext")]
		public string Description { get; set; }

		
		public long Duration { get; set; } 

		public virtual ICollection<Showtimes> Showtimes { get; set; }
	}
}
