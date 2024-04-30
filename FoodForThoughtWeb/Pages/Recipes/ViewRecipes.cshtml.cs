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
    public class ViewRecipesModel : PageModel
    {
		public List<SelectListItem> Cuisine { get; set; } = new List<SelectListItem>();
		public List<RecipeItem> Recipes { get; set; } = new List<RecipeItem>();
        public int SelectedCuisineId { get; set; }
        public void OnGet()
        {
            int americanCuisineId = 1;
            PopulateRecipe(americanCuisineId);
            PopulateCuisineDDL();
        }
		public void OnPost()
		{
			PopulateCuisineDDL();
			PopulateRecipe(SelectedCuisineId);
			
		}
		private void PopulateRecipe(int id)
		{
			using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
			{
				string cmdText = "SELECT DishName, Rating, Ingredients, Steps, RecipeId, Url FROM Recipe WHERE CuisineId = @itemId";
				SqlCommand cmd = new SqlCommand(cmdText, conn);
				cmd.Parameters.AddWithValue("@itemId", id);
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
						if(cuisine.Value == SelectedCuisineId.ToString())
						{
							cuisine.Selected= true;
						}
						Cuisine.Add(cuisine);

					}


				}
				


			}
		}
	}
}
