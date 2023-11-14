using System;
using System.Collections.Generic;

namespace Domain1;

public partial class Account
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int Role { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual TraineerProfile? TraineerProfile { get; set; }

    public virtual ICollection<ZooNews> ZooNews { get; set; } = new List<ZooNews>();
}
