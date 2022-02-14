using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.DataTransferObject
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}
