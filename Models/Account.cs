
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
	public class Account
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[EmailAddress]
		[Required]
		public string Email { get; set; }
		
		[Column(TypeName ="char")]
		[StringLength(64)]
		[Required(ErrorMessage = "Password id is required!!")]
		public string Password { get; set; }

		[StringLength(15)]
		public string FirstName { get; set; }

		[StringLength (15)]
		public string LastName { get; set; }

		[Column(TypeName = "varchar(2084)")]
		public string AvatarUrl { get; set; }

		public Role Role { get; set; }
	}
}
