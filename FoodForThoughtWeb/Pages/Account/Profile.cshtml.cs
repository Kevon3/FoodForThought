using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodForThoughtWeb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        [BindProperty]

        public UserProfile profile { get; set; }
        public void OnGet()
        {
        }
    }
}
