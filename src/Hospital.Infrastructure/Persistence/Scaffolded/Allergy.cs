using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Allergy
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public string Substance { get; set; } = null!;

    public string? Reaction { get; set; }

    public string? Severity { get; set; }

    public DateTime RecordedAt { get; set; }

    public Guid? RecordedBy { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual User? RecordedByNavigation { get; set; }
}
