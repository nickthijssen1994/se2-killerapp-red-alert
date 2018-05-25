using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords are not the same.")]
        public string ConfirmNewPassword { get; set; }
    }
}
