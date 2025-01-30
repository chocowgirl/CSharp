using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
    public class UserDelete
    {
        [DisplayName("First name")]
        public string First_Name { get; set; }


        [DisplayName("Last name")]
        public string Last_Name { get; set; }


        [DisplayName("Email addy")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
