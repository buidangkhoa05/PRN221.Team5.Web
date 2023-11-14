using System;
using System.Collections.Generic;

namespace Domain1;

public partial class Cage
{
    public Guid Id { get; set; }

    public int NumberCage { get; set; }

    public int Capacity { get; set; }

    public int Status { get; set; }

    public Guid ZooSectionId { get; set; }

    public Guid AnimalSpecieId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AnimalSpecy AnimalSpecie { get; set; } = null!;

    public virtual ICollection<CageAnimal> CageAnimals { get; set; } = new List<CageAnimal>();

    public virtual ZooSection ZooSection { get; set; } = null!;
}
