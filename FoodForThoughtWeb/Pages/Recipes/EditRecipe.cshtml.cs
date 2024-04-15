using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FoodForThoughtWeb.Pages.Recipes
{
	[BindProperties]
	public class EditRecipeModel : PageModel
    {
		public RecipeItem Item { get; set; } = new RecipeItem();

		public List<SelectListItem> Cuisine { get; set; } = new List<SelectListItem>();
		public void OnGet(int id)
        {
			PopulateRecipeItem(id);
			PopulateCuisineDDL();
		}
		public IActionResult OnPost(int id)
		{
			if (ModelState.IsValid)
			{
				using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
				{
					string cmdText = "UPDATE Recipe SET DishName = @dishName, Rating = @rating,Ingredients=@ingredients, Steps=@steps, CuisineId = @cuisineId WHERE RecipeId= @itemId";
					SqlCommand cmd = new SqlCommand(cmdText, conn);
					cmd.Parameters.AddWithValue("@itemId", id);
					cmd.Parameters.AddWithValue("@dishName", Item.DishName);
					cmd.Parameters.AddWithValue("@rating", Item.Rating);
					cmd.Parameters.AddWithValue("@ingredients", Item.Ingredients);
					cmd.Parameters.AddWithValue("@steps", Item.Steps);
					cmd.Parameters.AddWithValue("@cuisineId", Item.CuisineId);
					

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
		private void PopulateRecipeItem(int id)
		{
			using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
			{
				string cmdText = "SELECT DishName, Rating, Ingredients, Steps, CuisineId FROM Recipe WHERE RecipeId=@itemId";
				SqlCommand cmd = new SqlCommand(cmdText, conn);
				cmd.Parameters.AddWithValue("@itemId", id);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					Item.RecipeId = id;
					Item.DishName = reader.GetString(0);
					Item.Rating = reader.GetInt32(1);
					Item.Ingredients = reader.GetString(2);
					Item.Steps = reader.GetString(3);
					Item.CuisineId = reader.GetInt32(4);
				}
			}
				
		}

	}
}
