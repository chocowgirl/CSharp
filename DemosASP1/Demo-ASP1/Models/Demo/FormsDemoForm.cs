using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP1.Models.Demo
{
    public class FormsDemoForm
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "Please choose a title")]
        public string Title { get; set; }

        [DisplayName("Last Name")]
        [Required (ErrorMessage = "Le champs Nom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs Nom doit contenir au moins 2 charactères")]
        [MaxLength(64, ErrorMessage = "Le champs Nom doit contenir au max 64 charactères")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        [Required (ErrorMessage = "Le champs prenom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs prenom doit contenir au moins 2 charactères")]
        [MaxLength(64, ErrorMessage = "Le champs prenom doit contenir au max 64 charactères")]
        public string FirstName { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Le champ date de naissance est obligatoire.")]
        [DataType("datetime-local")]
        public DateOnly BirthDate { get; set; }


    }
}
