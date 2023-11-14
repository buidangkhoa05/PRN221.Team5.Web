using System;
using System.Collections.Generic;

namespace Domain1;

public partial class Animal
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public float Weight { get; set; }

    public float Height { get; set; }

    public float Age { get; set; }

    public int Gender { get; set; }

    public bool IsHerd { get; set; }

    public Guid SpecieId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime Dob { get; set; }

    public virtual ICollection<AnimalTraining> AnimalTrainings { get; set; } = new List<AnimalTraining>();

    public virtual ICollection<CageAnimal> CageAnimals { get; set; } = new List<CageAnimal>();

    public virtual ICollection<MealAnimal> MealAnimals { get; set; } = new List<MealAnimal>();

    public virtual AnimalSpecy Specie { get; set; } = null!;
}
