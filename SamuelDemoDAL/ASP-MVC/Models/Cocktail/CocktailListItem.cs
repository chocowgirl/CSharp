using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ASP_MVC.Models.Cocktail
{
    public class CocktailListItem
    {
        //[ScaffoldColumn(false)] //this makes this champs not visible to the user
        public Guid Cocktail_Id { get; set; }


        [DisplayName("Cocktail name:")]
        public string Name { get; set; }


        [DisplayName("Cocktail description:")]
        public string? Description { get; set; }



        [DisplayName("Cocktail preparation instructions:")]
        public string Instructions { get; set; }



        [DisplayName("Cocktail created date:")]
        public DateOnly CreatedAt { get; set; }



        [DisplayName("Cocktail created by:")]
        public Guid? CreatedBy { get; set; }
    }
}
