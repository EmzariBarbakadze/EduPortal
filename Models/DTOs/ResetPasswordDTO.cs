using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EduPortal.Models.DTOs
{
    public class ResetPasswordDTO
    {
        [NotNull, Required, EmailAddress]
        public string Email { get; set; }
        public int PinCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RepeatPassword { get; set; }
    }
}
