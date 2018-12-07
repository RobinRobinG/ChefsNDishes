using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required]
        [MinLength(3, ErrorMessage = "Name must be 3 characters or longer.")]
        [Display(Name = "Dish Name:")]
        public string Name {get;set;}

        [MinLength(10, ErrorMessage = "Description must be 10 characters or longer.")]
        [Display(Name = "Description:")]
        public string Description {get;set;}

        [Required]
        [Display(Name = "Tastiness:")]
        public int Tastiness {get;set;}
        public int ChefId {get;set;}
        public Chef DishChef {get;set;}
    }
}