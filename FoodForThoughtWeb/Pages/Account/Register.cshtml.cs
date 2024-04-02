using FoodForThoughtWeb.Model;
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
                string connString = "Server=(localdb)\\MASQLLocalDB;Database=FoodForThought; Trusted_Connection = true;";
                SqlConnection conn = new SqlConnection(connString);
                string cmdText = "INSERT INTO Person(Username,FirstName, LastName, Email, Password)" + " VALUES(@firstName, @lastName, @email, @password,@username)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", NewPerson.Username);
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
                // Return the page with validation errors
                return Page();
            }

        }
    }
}
        
    

