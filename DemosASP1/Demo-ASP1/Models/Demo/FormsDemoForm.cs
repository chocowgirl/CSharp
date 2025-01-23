using System.ComponentModel.DataAnnotations;

namespace Demo_ASP1.Models.Demo
{
    public class FormsDemoForm
    {
        [Required (ErrorMessage = "Le champs Nom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs Nom doit contenir au moins 2 charactères")]
        [MaxLength(64, ErrorMessage = "Le champs Nom doit contenir au max 64 charactères")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Le champs prenom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs prenom doit contenir au moins 2 charactères")]
        [MaxLength(64, ErrorMessage = "Le champs prenom doit contenir au max 64 charactères")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ date de naissance est obligatoire.")]
        public DateOnly BirthDate { get; set; }


    }
}
