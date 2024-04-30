using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FoodForThoughtWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<RecipeItem> Recipes { get; set; } = new List<RecipeItem>();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PopulateRecipes();
        }
        public void OnPost()
        {
            PopulateRecipes();
        }
        private void PopulateRecipes()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT DishName, Rating,Ingredients, Steps, RecipeId, url FROM Recipe";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new RecipeItem();
                        item.DishName = reader.GetString(0);
                        item.Rating = reader.GetInt32(1);
                        item.Ingredients = reader.GetString(2);
                        item.Steps = reader.GetString(3);
                        item.RecipeId = reader.GetInt32(4);
						// Check if URL value is null before assigning it
						if (!reader.IsDBNull(5))
						{
							item.url = reader.GetString(5); // Set the URL property
						}
						Recipes.Add(item);
					}


                }



            }
        }
    }
   
}
