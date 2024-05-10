using System.ComponentModel.DataAnnotations;

namespace FoodForThoughtWeb.Model
{
    public class Person
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must be a combination of uppercase & lowercase letters and numbers.")]
        [StringLength(50, ErrorMessage = "Password must be less than 50 characters.")]
        [MinLength(10, ErrorMessage = "Password must be greater than 10 characters.")]
        public string Password { get; set; }

        public int AllergyId { get; set; }
    }
}
