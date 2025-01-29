using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP1.Models.Demo
{
    public class UserListItem
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        //the above makes UserId invisible when the page is generated.
        public int UserId { get; set; }


        [DisplayName("Prenom")]
        public string FirstName { get; set; }


        [DisplayName("Nom")]
        public string LastName { get; set; }

    }
}
