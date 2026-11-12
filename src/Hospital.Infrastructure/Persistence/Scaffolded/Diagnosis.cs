using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Diagnosis
{
    public Guid Id { get; set; }

    public Guid EncounterId { get; set; }

    public string ICD10Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public DateTime RecordedAt { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;
}
