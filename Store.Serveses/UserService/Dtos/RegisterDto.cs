using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.UserService.Dtos
{
	public class RegisterDto
	{
		[Required]
		public string DisplayName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[RegularExpression(@"^(?=(.*[A-Z]){1})(?=(.*[a-z]){1})(?=(.*\d){1})(?=(.*\W){1})(?!.*(.)\1\1).{8,}$", ErrorMessage = "Password must meet the complexity requirements.")]

		public string Password { get; set; }
	}
}
