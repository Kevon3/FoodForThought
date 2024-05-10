using System.ComponentModel.DataAnnotations;

namespace FoodForThoughtWeb.Model
{
    public class UserProfile
    {
       // public int UserId { get; set; }
        //[Required]

        [Required(ErrorMessage = "The Username field is required.")]
        //[Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }
       

        //[Required]
       

    }
}
