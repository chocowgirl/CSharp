using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
    public class UserDetails
    {
        [ScaffoldColumn(false)]
        public Guid User_Id { get; set; }


        [DisplayName("Prénommm:")]
        public string First_Name { get; set; }


        [DisplayName("Nom de famiiiille:")]
        public string Last_Name { get; set; }


        [DisplayName("Emailaroo:")]
        [EmailAddress]
        public string Email { get; set; }


        [DisplayName("Date d'inscription:")]
        [DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }
    }
}
