using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP1.Models.Demo
{
    public class UserCreateForm
    {
        [DisplayName("Prenom : ")]
        [Required(ErrorMessage = "Le champ prenom est obligatoire")]
        [MinLength(2, ErrorMessage = "le champ prenom doit contenir au moins 2 characteres")]
        [MaxLength(64, ErrorMessage = "le champ prenom doit contenir au max 64 characteres")]
        public string FirstName { get; set; }


        [DisplayName("Nom : ")]
        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        [MinLength(2, ErrorMessage = "le champ nom doit contenir au moins 2 characteres")]
        [MaxLength(64, ErrorMessage = "le champ prenom doit contenir au max 64 characteres")]
        public string LastName { get; set; }


        [DisplayName("Email : ")]
        [Required(ErrorMessage = "Le champ email est obligatoire")]
        [EmailAddress(ErrorMessage = "le champ email ne correspond pas a une addresse email valide")]
        public string Email { get; set; }
    }
}
