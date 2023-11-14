using System;
using System.Collections.Generic;

namespace Domain1;

public partial class TraineerProfile
{
    public Guid Id { get; set; }

    public DateTime JoinDate { get; set; }

    public DateTime? OutDate { get; set; }

    public string Exprerience { get; set; } = null!;

    public Guid AccountId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<AnimalTraining> AnimalTrainings { get; set; } = new List<AnimalTraining>();
}
