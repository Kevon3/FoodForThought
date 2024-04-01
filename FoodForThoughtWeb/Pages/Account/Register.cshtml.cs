using FoodForThoughtWeb.Pages.Model;
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
        public ActionResult OnPost() {
            if (ModelState.IsValid)
            {
                string connString = "Server=(local)\\MASQLocalDB;Database=FoodForThought; Trusted_Connection = true;";
                SqlConnection conn = new SqlConnection(connString);
                string cmdText = "INSERT INTO USER(FirstName, LastName, Email,Username Password)" + " VALUES(@firstName, @lastName, @email, @password,@username, @allergyId, @userId)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
				cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@username", NewPerson.Username);
				cmd.Parameters.AddWithValue("@password", NewPerson.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToPage("Login");
			}
            else
            {
                return Page();
            }
        }
    }
}
