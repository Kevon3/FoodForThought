using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FoodForThoughtWeb.Pages.Recipes
{
    [BindProperties]
    public class ViewRecipesModel : PageModel
    {
		public List<SelectListItem> Cuisine { get; set; } = new List<SelectListItem>();
		public List<RecipeItem> Recipes { get; set; } = new List<RecipeItem>();
        public int SelectedCuisineId { get; set; }
        public void OnGet()
        {
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
				string cmdText = "SELECT DishName, Rating, RecipeId FROM Recipe WHERE CuisineId = @itemId";
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
						item.RecipeId = reader.GetInt32(2);
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
