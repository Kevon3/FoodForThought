﻿using System.ComponentModel.DataAnnotations;

namespace FoodForThoughtWeb.Model
{
    public class Person
    {

        public int UserId { get; set; }
        //[Required]

        [Required(ErrorMessage = "The Username field is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "The First Name field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //[Required]

        //[Required]
        public int AllergyId { get; set; }
        //public int UserId {  get; set; }
    }
}
