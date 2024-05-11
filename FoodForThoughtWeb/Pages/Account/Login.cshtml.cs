using FoodForThoughtBusiness;
using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

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
                if (ValidateCredentials())
                {
                    return RedirectToPage("Profile");
                }
                
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");

                }
                return Page();

            }
            else
            {
                return Page();
            }

        }

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString())
)
            {
                string cmdText = "SELECT Password, UserId, FirstName FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if(reader.IsDBNull(0))
                    {
                        return false;
                    }
                    else
                    {
                        string passwordHash = reader.GetString(0);
                        if(SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                        {
                            int userId = reader.GetInt32(1);

                            string name = reader.GetString(2);
                           

                            //Create a list of claims
                            Claim emailClaim = new Claim(ClaimTypes.Email, LoginUser.Email);
                            Claim nameClaim = new Claim(ClaimTypes.Name, name);

                            List<Claim> claims = new List<Claim> { emailClaim, nameClaim };

                            //2. Create a ClaimIdentity
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            //3. Create a ClaimsPrincipal
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            //4. Create an authentication Cookie
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                            return true;    
                        }else { 
                            return false; 
                        }
                    }
                }
                else
                {
                    return false;
                }


            }
        }

    }

}

