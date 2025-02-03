using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDetails
    {
        //[ScaffoldColumn(false)]
        [DisplayName("Cocktail Id:")]
        public Guid Cocktail_Id { get; set; }



        [DisplayName("Cocktail name:")]
        public string Name { get; set; }



        [DisplayName("Description:")]
        public string? Description { get; set; }



        [DisplayName("Cocktail preparation instructions:")]
        [EmailAddress]
        public string Instructions { get; set; }



        [DisplayName("Cocktail date of creation:")]
        //[DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }



        [DisplayName("Cocktail created by:")]
        public Guid? CreatedBy { get; set; }


    }
}
