using FoodForThoughtWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodForThoughtWeb.Pages.Account
{
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
            profile.Username = "h";
            profile.FirstName = "Kevin";
            profile.LastName = "Harvey";
            profile.Email = "h@gmail.com";
        }
    }
}
