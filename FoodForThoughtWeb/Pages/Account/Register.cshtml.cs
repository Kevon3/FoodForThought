using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FoodForThoughtWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; }
        public void OnGet()
        {

        }

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
                if (!IsPasswordValid(NewPerson.Password))
                {
                    ModelState.AddModelError("RegisterError", "Password must be at least 10 characters. :)");
                    return Page();
                }
                    if (UsernameExists(NewPerson.Username))
				{
					ModelState.AddModelError("RegisterError", "This username exists, please try another one.");
					return Page();
				}
				if (EmailDoesNotExist(NewPerson.Email))
				{
					RegisterUser();
					return RedirectToPage("Login");
				}
				else
				{
					ModelState.AddModelError("RegisterError", "This email already exists. Try a different one.");
					return Page();
				}

				
			}
			
			else
			{
				// Return the page with validation errors
				return Page();
			}
		}

		private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO Person(Username,FirstName, LastName, Email, Password)" + " VALUES(@username, @firstName, @lastName, @email, @password)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", NewPerson.Username);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(NewPerson.Password));

                conn.Open();
                cmd.ExecuteNonQuery(); 
            }
        }

        private bool EmailDoesNotExist(string email)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

        private bool IsPasswordValid(string password)
        {
            return password.Length >= 10;
        }

    }
}
//string connString = "Server=(localdb)\\MASQLLocalDB;Database=FoodForThought; Trusted_Connection = true;";
/*SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
string cmdText = "INSERT INTO Person(Username,FirstName, LastName, Email, Password)" + " VALUES(@username, @firstName, @lastName, @email, @password)";
SqlCommand cmd = new SqlCommand(cmdText, conn);
cmd.Parameters.AddWithValue("@username", NewPerson.Username);
cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
cmd.Parameters.AddWithValue("@email", NewPerson.Email);
cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(NewPerson.Password));

conn.Open();
cmd.ExecuteNonQuery();*/


//return RedirectToPage("Login");



