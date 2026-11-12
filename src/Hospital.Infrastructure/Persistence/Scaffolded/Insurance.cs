using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Insurance
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public string Provider { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public DateOnly? ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
