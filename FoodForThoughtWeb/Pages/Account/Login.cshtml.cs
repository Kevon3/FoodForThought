using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Runtime.Intrinsics.X86;

namespace FoodForThoughtWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                String cmdText = "SELECT Password FROM Person WHERE Email=@email;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                        {
                            return RedirectToPage("Login");
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");
                            return Page();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");

                }
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


