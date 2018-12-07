using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required]
        [MinLength(3, ErrorMessage = "First Name must be 3 characters or longer.")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(3, ErrorMessage = "Last Name must be 3 characters or longer.")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}

        [Required]
        [FutureDate]
        [MinAge(AgeInYears = 18)]
        [Display(Name = "Birthday:")]
        public DateTime Birthday {get; set;}

        public List<Dish> Dishes {get;set;}
    }
}