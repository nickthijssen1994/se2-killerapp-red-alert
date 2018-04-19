using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
    public class LoginOrRegisterViewModel
    {
        public LoginViewModel LoginModel { get; set; }
        public RegisterViewModel RegisterModel { get; set; }
    }

    public class RegisterViewModel
    {
        [Required, EmailAddress, MaxLength(50), Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required, MinLength(10), MaxLength(50), Display(Name = "Username")]
        public string Username { get; set; }
        [Required, MinLength(10), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Required, MinLength(10), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not the same.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required, MinLength(10), MaxLength(50), Display(Name = "Username")]
        public string Username { get; set; }
        [Required, MinLength(10), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
