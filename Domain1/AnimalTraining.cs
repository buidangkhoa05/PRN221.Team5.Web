using System;
using System.Collections.Generic;

namespace Domain1;

public partial class AnimalTraining
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsTraining { get; set; }

    public Guid TrainerId { get; set; }

    public Guid AnimalId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual TraineerProfile Trainer { get; set; } = null!;
}
