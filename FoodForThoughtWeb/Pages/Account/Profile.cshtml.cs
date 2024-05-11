using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace FoodForThoughtWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]

        public UserProfile profile { get; set; } = new UserProfile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Username FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    profile.FirstName = reader.GetString(0);
                    profile.LastName = reader.GetString(1);
                    profile.Email = email;
                    profile.Username = reader.GetString(3);

                }
            }
        }
    }
}
