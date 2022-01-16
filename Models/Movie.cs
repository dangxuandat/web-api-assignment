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
	public class Movie
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(256)]
		public string Title { get; set; }

		[StringLength(100)]
		public string Director { get; set; }

		[Column(TypeName = "ntext")]
		public string Description { get; set; }

		public long Duration { get; set; }

		public virtual IList<MovieCast> MovieCasts { get; set; }
		public virtual IList<MovieShowtimes> MovieShowtimes { get; set; }

		public virtual IList<MovieCategory> MovieCategories { get; set; }
	}
}
