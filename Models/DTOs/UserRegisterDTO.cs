using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.DTOs
{
    public class UserRegisterDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RepeatPassword { get; set; }
    }
}
