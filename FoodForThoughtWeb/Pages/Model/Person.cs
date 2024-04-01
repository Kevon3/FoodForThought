using System.ComponentModel.DataAnnotations;

namespace FoodForThoughtWeb.Pages.Model
{
	public class Person
	{
		[Required]
		public int UserID { get; set; }
		[Required]
		public string FirstName {  get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email {  get; set; }
		[Required]
		public string Password {  get; set; }
		[Required]
		public string Username {  get; set; }
		//[Required]
		public int AllergyID { get; set; }
		//public int UserId {  get; set; }
	}
}
