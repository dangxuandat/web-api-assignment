using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.DataTransferObject
{
    public class UpdateMovieDTO
    {

		[StringLength(256)]
		public string Title { get; set; }

		[StringLength(100)]
		public string Director { get; set; }

		public string Description { get; set; }

		public long Duration { get; set; }

	}
}
