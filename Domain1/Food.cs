using System;
using System.Collections.Generic;

namespace Domain1;

public partial class Food
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<MealFood> MealFoods { get; set; } = new List<MealFood>();
}
