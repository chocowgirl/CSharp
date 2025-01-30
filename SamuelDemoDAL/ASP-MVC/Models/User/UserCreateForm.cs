using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
    public class UserCreateForm
    {
        [Required(ErrorMessage ="you have to fill out the Prénom field")]
        [MaxLength(64, ErrorMessage ="The first name field cannot have more than 64 characters")]
        [MinLength(2, ErrorMessage = "The first name field must have at least 2 characters")]
        [DisplayName("Prénommm:")]
        public string First_Name { get; set; }


        [Required(ErrorMessage = "you have to fill out the Nom de famille field")]
        [MaxLength(64, ErrorMessage = "The last name field cannot have more than 64 characters")]
        [MinLength(2, ErrorMessage = "The last name name field must have at least 2 characters")]
        [DisplayName("Nom de famiiiille:")]
        public string Last_Name { get; set; }


        [Required(ErrorMessage = "you have to fill out the Email field")]
        [DisplayName("Emailaroo:")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "you have to fill out the Password field")]
        [MaxLength(64, ErrorMessage = "The Password field cannot have more than 64 characters")]
        [MinLength(2, ErrorMessage = "The Password field must have at least 2 characters")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_=+\.()\[\]$µ£\\§?{}/]).*", ErrorMessage ="The Password field must contain at least one lowercase, one uppercase, one number and one symbol.")]
        [DisplayName("Secret word")]
        public string Password { get; set; }


        [Required(ErrorMessage = "you have to fill out the Password confirmation field")]
        [DisplayName("Same Secret word")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The confirmation password does not match the original password given")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage ="You must read and accept the terms and conditions of service")]
        [DisplayName("In checking this box you indicate you have read and accept our terms and conditions of service.")]
        public bool Consent { get; set; }
    }
}
