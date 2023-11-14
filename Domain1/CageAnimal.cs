using System;
using System.Collections.Generic;

namespace Domain1;

public partial class CageAnimal
{
    public Guid Id { get; set; }

    public Guid CageId { get; set; }

    public Guid AnimalId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsPresent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Cage Cage { get; set; } = null!;
}
