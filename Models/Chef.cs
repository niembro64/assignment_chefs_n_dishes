using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace assignment_chefs_n_dishes.Models
{
  public class Chef
  {
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.PastDate))]
    [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.Not18))]
    public DateTime Birthday { get; set; }

    // navigation property
    public List<Dish> Dishes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
  }

  public class CustomValidationMethods
  {
    public static ValidationResult PastDate(DateTime date)
    {
      return DateTime.Compare(date, DateTime.Today) > 0 ? new ValidationResult("Date cannot be in the future") : ValidationResult.Success;
    }

    public static ValidationResult Not18(DateTime date)
    {
      return DateTime.Compare(date, DateTime.Today) > 0 ? new ValidationResult("Must be at least 18") : ValidationResult.Success;
    }
  }
}