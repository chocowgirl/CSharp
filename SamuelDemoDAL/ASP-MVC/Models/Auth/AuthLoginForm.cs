using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Auth
{
    public class AuthLoginForm
    {
        [Required(ErrorMessage = "you have to fill out the Email field")]
        [DisplayName("Emailaroo:")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "you have to fill out the Password field")]
        [MaxLength(64, ErrorMessage = "The Password field cannot have more than 64 characters")]
        [MinLength(2, ErrorMessage = "The Password field must have at least 2 characters")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_=+\.()\[\]$µ£\\§?{}/]).*", ErrorMessage = "The Password field is not valid.")]
        [DisplayName("Secret word")]
        public string Password { get; set; }

    }
}
