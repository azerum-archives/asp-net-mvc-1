using System.ComponentModel.DataAnnotations;

namespace Intro.Models.ViewModels
{
    public class UserRegistrationVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
