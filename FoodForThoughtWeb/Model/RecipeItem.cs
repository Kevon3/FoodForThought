using System.ComponentModel.DataAnnotations;

namespace FoodForThoughtWeb.Model
{
    public class RecipeItem
    {
        public int RecipeId { get; set; }
        
        [Display(Name = "Name of Dish: ")]
        [Required]
        public string DishName { get; set; }
        [Required]
        [Display(Name = "Rating of difficulty: ")]
        public int Rating { get; set; }
        [Required]
        [Display(Name = "Cuisine: ")]
        public int CuisineId {  get; set; }
       // [Required]
       /* [Display(Name = "Ingredients + Steps:  ")]
        public int IngredientId { get; set; }*/
        
    }
}
