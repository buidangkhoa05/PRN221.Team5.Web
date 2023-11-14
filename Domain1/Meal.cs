using System;
using System.Collections.Generic;

namespace Domain1;

public partial class Meal
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public float FoodFrequency { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MealAnimal> MealAnimals { get; set; } = new List<MealAnimal>();

    public virtual ICollection<MealFood> MealFoods { get; set; } = new List<MealFood>();
}
