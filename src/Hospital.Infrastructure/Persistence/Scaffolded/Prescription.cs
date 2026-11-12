using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Prescription
{
    public Guid Id { get; set; }

    public Guid EncounterId { get; set; }

    public string Drug { get; set; } = null!;

    public string Dose { get; set; } = null!;

    public string Frequency { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;
}
