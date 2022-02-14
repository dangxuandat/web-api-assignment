using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.DataTransferObject
{
    public class NewMovieDTO
    {
		[Required]
		[StringLength(256)]
		public string Title { get; set; }
		[Required]
		[StringLength (100)]
		public string Director { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public long Duration { get; set; }

		[Required]
		public IEnumerable<string> NameOfCasts { get; set; }

		[Required]
		public IEnumerable<Guid> Categories { get; set; }
	}
}
