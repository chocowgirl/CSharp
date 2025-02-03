using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailEditForm
    {
        [Required(ErrorMessage = "you have to give the cocktail a name")]
        [MaxLength(64, ErrorMessage = "The first name field cannot have more than 64 characters")]
        [MinLength(2, ErrorMessage = "The first name field must have at least 2 characters")]
        [DisplayName("Cocktail name:")]
        public string Name { get; set; }


        [MaxLength(512, ErrorMessage = "The cocktail description name may not be longer than 512 characters")]
        [MinLength(2, ErrorMessage = "The cocktail description must have at least 2 characters")]
        [DisplayName("Cocktail description:")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "You must provide preparation instructions for the cocktail")]
        [MinLength(2, ErrorMessage = "The cocktail description must have at least 2 characters")]
        [DisplayName("Cocktail preparation instructions:")]
        public string Instructions { get; set; }


        [Required(ErrorMessage = "A user ID must be attributed to the creation of a cocktail")]
        [DisplayName("Cocktail creator id:")]
        public Guid CreatedBy { get; set; }


    }
}
