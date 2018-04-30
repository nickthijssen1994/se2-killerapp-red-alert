using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
    public class LoginAndRegisterViewModel
    {
        public LoginViewModel LoginModel { get; set; }
        public RegisterViewModel RegisterModel { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string LoginUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool LoginRememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        public string RegisterEmail { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Username")]
        public string RegisterUsername { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("RegisterPassword", ErrorMessage = "Passwords are not the same.")]
        public string RegisterConfirmPassword { get; set; }
    }
}
