using System;
using System.Collections.Generic;

namespace Domain1;

public partial class ZooNews
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ImageLink { get; set; } = null!;

    public Guid OwnerId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Account Owner { get; set; } = null!;
}
