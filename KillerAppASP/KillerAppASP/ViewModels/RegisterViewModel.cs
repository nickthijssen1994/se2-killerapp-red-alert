using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "{0} is required.")]
		[EmailAddress(ErrorMessage = "{0} is not valid.")]
		[MaxLength(50)]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
		[RegularExpression(@"^[a-zA-Z0-9]+([a-zA-Z0-9])*$",
			ErrorMessage = "{0} can only consist of letters and numbers.")]
		[StringLength(20, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 6)]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(20, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Passwords are not the same.")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Login after registration?")]
		public bool AutoLogin { get; set; }

		[Display(Name = "Remember me after registration?")]
		public bool RememberMe { get; set; }
	}
}