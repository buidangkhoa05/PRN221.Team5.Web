using System;
using System.Collections.Generic;

namespace Domain1;

public partial class MealAnimal
{
    public Guid Id { get; set; }

    public Guid MealId { get; set; }

    public Guid AnimalId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Meal Meal { get; set; } = null!;
}
