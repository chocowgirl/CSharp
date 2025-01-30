using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
    public class UserEditForm
    {
        [Required(ErrorMessage = "you have to fill out the Prénom field")]
        [MaxLength(64, ErrorMessage = "The first name field cannot have more than 64 characters")]
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
    }
}
