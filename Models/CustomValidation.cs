using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
namespace ChefsNDishes.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Parse(value.ToString()) > DateTime.Now)
            {
                return new ValidationResult("Please enter a future date.");
            }
            return ValidationResult.Success;
        }
    }

    public class MinAgeAttribute : ValidationAttribute
    {
        public int AgeInYears { get; set; }

        // Implement IsValid method:
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check that the age is more than the minimum requested
            if (DateTime.Parse(value.ToString()).AddYears(AgeInYears) > DateTime.Now)
            {
                return new ValidationResult("You are not yet 18 years old");
            }
            return ValidationResult.Success;
        }
    }
}