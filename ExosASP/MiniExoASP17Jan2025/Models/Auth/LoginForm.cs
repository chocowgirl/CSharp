using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MiniExoASP17Jan2025.Models.Auth
{
    public class LoginForm
    {
        [DisplayName("Email address:")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "The entry here must use a valid email address format")]
        public string Email { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        [MaxLength(32, ErrorMessage = "The password cannot be more than 32 characters long")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[#?!@$ %^&*\-]).{8,32}", ErrorMessage = "Le mot de passe ne correspond pas.")]
        public string Password { get; set; }
    }
}
