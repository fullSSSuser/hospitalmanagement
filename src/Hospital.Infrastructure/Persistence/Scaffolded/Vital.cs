using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Vital
{
    public Guid Id { get; set; }

    public Guid EncounterId { get; set; }

    public string? BloodPressure { get; set; }

    public int? HeartRate { get; set; }

    public decimal? Temperature { get; set; }

    public int? SpO2 { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public DateTime RecordedAt { get; set; }

    public Guid? RecordedBy { get; set; }

    public bool IsAbnormal { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual User? RecordedByNavigation { get; set; }
}
