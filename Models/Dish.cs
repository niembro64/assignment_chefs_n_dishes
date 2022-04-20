using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace assignment_chefs_n_dishes.Models
{
  public class Dish
  {
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(0,double.PositiveInfinity)]
    public int Calories { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }
    [Required]
    public string Description { get; set; }

  public int ChefId { get; set; }

    // navigation property
    public Chef Cooker { get; set; }


  
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
  }
}