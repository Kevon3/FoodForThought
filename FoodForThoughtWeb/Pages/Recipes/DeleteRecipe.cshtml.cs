using FoodForThoughtBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FoodForThoughtWeb.Pages.Recipes
{
	[BindProperties]
	[Authorize]
	public class DeleteRecipeModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Recipe WHERE RecipeId=@itemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewRecipes");
            }
        }
    }
}
