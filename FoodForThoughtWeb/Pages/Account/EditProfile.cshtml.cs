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
    public class EditProfileModel : PageModel
    {
        [BindProperty]

        public Person profile { get; set; } = new Person();
        public List<Person> People { get; set; } = new List<Person>();

        public void OnGet(int id)
        {
            PopulateProfile(id);
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Person SET Username = @username, FirstName = @firstName, LastName = @lastName, Email = @email, Password = @password WHERE UserId = @userId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@userId", profile.UserId);
                    cmd.Parameters.AddWithValue("@username", profile.Username);
                    cmd.Parameters.AddWithValue("@firstName", profile.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", profile.LastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(profile.Password));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("Profile");
                }
            }
            else
            {
                return Page();
            }
        }
        private Person PopulateProfile(int id)
        {
            Person item = null;
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Username FROM Person WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        profile = new Person();

                        profile.FirstName = reader.GetString(0);
                        profile.LastName = reader.GetString(1);
                        profile.Email = email;
                        profile.Username = reader.GetString(3);
                    }
                }
                return item;
            }
        }
        private bool UsernameExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Username=@username";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool EmailDoesExist(string email)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
