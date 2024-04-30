using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;


namespace FoodForThoughtWeb.Pages.Recipes
{
	[BindProperties]
    [Authorize]
	public class AddRecipeModel : PageModel
    {
        
        public RecipeItem newRecipeItem { get; set; } = new RecipeItem();

       
        public List<SelectListItem> Cuisine { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateCuisineDDL();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Recipe(DishName, Rating, Ingredients, Steps, CuisineId, url) " +
                    "VALUES (@dishName, @rating, @ingredients, @steps, @cuisineId, @url)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@dishName", newRecipeItem.DishName);
                    cmd.Parameters.AddWithValue("@rating", newRecipeItem.Rating);
                    cmd.Parameters.AddWithValue("@cuisineId", newRecipeItem.CuisineId);
                    cmd.Parameters.AddWithValue("@ingredients", newRecipeItem.Ingredients);
                    cmd.Parameters.AddWithValue("@steps", newRecipeItem.Steps);

                    // Check if url is null before adding the parameter
                    if (newRecipeItem.url != null)
                    {
                        cmd.Parameters.AddWithValue("@url", newRecipeItem.url);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@url", DBNull.Value); // or null, depending on the database type
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewRecipes");
                }
            }
            else
            {
                return Page();
            }
        }

        private void PopulateCuisineDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT CuisineId, Cuisine FROM Cuisine ORDER BY Cuisine";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cuisine = new SelectListItem();
                        cuisine.Value = reader.GetInt32(0).ToString();
                        cuisine.Text = reader.GetString(1);
                        Cuisine.Add(cuisine);
						
					}
					

				}
				


			}
        }
    }
}
/*
 * string cmdText = "SELECT CuisineId, Cuisine FROM Cuisine";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    var cuisine = new SelectListItem();
                    cuisine.Value = reader.GetInt32(0).ToString();
                    cuisine.Text = reader.GetString(1);
                    Cuisine.Add(cuisine);
                }

while (reader.Read())
                {
                    var cuisine = new SelectListItem();
                    cuisine.Value = reader.GetInt32(0).ToString();
                    cuisine.Text = reader.GetString(1);
                    Cuisine.Add(cuisine);
                }
    */
