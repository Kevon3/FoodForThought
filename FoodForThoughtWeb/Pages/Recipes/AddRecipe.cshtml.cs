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
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if required fields are not filled out
                    if (string.IsNullOrWhiteSpace(newRecipeItem.DishName))
                        ModelState.AddModelError("newRecipeItem.DishName", "Name of Dish is required.");
                    if (newRecipeItem.Rating == 0)
                        ModelState.AddModelError("newRecipeItem.Rating", "Rating of difficulty is required.");
                    if (newRecipeItem.CuisineId == 0)
                        ModelState.AddModelError("newRecipeItem.CuisineId", "Cuisine is required.");
                    if (string.IsNullOrWhiteSpace(newRecipeItem.Ingredients))
                        ModelState.AddModelError("newRecipeItem.Ingredients", "Ingredients are required.");
                    if (string.IsNullOrWhiteSpace(newRecipeItem.Steps))
                        ModelState.AddModelError("newRecipeItem.Steps", "Steps are required.");

                    // If any required field is not filled out, return the page with error messages
                    if (!ModelState.IsValid)
                    {
                        PopulateCuisineDDL(); // Repopulate cuisine dropdown
                        return Page();
                    }

                    // Your database insertion code
                    using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                    {
                        // Your database insertion logic
                    }

                    return RedirectToPage("ViewRecipes");
                }
                else
                {
                    // Model validation failed
                    PopulateCuisineDDL(); // Repopulate cuisine dropdown
                    return Page();
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                ModelState.AddModelError("", "An error occurred while saving the recipe. Please try again later.");
                PopulateCuisineDDL(); // Repopulate cuisine dropdown
                return Page();
            }
            catch (Exception ex)
            {
                // Handle generic exceptions
                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                PopulateCuisineDDL(); // Repopulate cuisine dropdown
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
