using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniExoASP17Jan2025.Models.Auth
{
    public class RegisterForm
    {
        [DisplayName("Name:")]
        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(2, ErrorMessage = "The first name must have at least 2 letters")]
        [MaxLength(64, ErrorMessage = "The first name cannot have more than 64 letters")]
        public string Name { get; set; }


        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(2, ErrorMessage = "The first name must have at least 2 letters")]
        [MaxLength(64, ErrorMessage = "The first name cannot have more than 64 letters")]
        public string LastName { get; set; }


        [DisplayName("Date of birth:")]
        [Required(ErrorMessage = "Please enter your birthdate")]
        [DataType(DataType.Date)]
        //**************INSERT BIRTHDAY VALIDATION CALCULATION BELOW
        //VOIR VALIDATION HANDLER
        public DateOnly Birthday { get; set; }


        [DisplayName("Email address:")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "The entry here must use a valid email address format")]
        public string Email { get; set; }


        [DisplayName("Password:")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        [MaxLength(32, ErrorMessage = "The password cannot be more than 32 characters long")]
        //[RegularExpression("^(?=.*?[a - z])(?=.*?[A - Z])(?=.*?[0 - 9])(?=.*?[#?!@$ %^&*-])$")]
        public string Password { get; set; }


        [DisplayName("Confirm Password:")]
        [Required(ErrorMessage = "Please re-enter your password")]
        [DataType(DataType.Password)]
        //[MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        //[MaxLength(32, ErrorMessage = "The password cannot be more than 32 characters long")]
        //[RegularExpression("^(?=.*?[a - z])(?=.*?[A - Z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-])$", ErrorMessage = "Must contain at least one lower-case letter, at least one uppercase letter, at least one number and at least one symbol")]
        [Compare(nameof(Password), ErrorMessage = "The second password entered does not exactly match the first!")]
        public string PasswordConf { get; set; }
    }
}
