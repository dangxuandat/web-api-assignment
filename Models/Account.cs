using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
	public class Account
	{
		[Key]
		[Required(ErrorMessage = "Account id is required!!")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
	
		[StringLength(15)]
		[Required(ErrorMessage = "Username is required!!")]
		public string UserName { get; set; }
		
		[Column(TypeName ="char")]
		[StringLength(64)]
		[Required(ErrorMessage = "Password id is required!!")]
		public string Password { get; set; }

		[StringLength(15)]
		public string FirstName { get; set; }

		[StringLength (15)]
		public string LastName { get; set; }

		public Role Role { get; set; }
	}
}
