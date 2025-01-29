using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo_ASP1.Models.Demo
{
    public class UserEditForm
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

    }
}
