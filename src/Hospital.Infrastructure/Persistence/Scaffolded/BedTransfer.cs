using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class BedTransfer
{
    public Guid Id { get; set; }

    public Guid AdmissionId { get; set; }

    public Guid FromBedId { get; set; }

    public Guid ToBedId { get; set; }

    public string? Reason { get; set; }

    public DateTime MovedAt { get; set; }

    public Guid? MovedBy { get; set; }

    public virtual Admission Admission { get; set; } = null!;

    public virtual Bed FromBed { get; set; } = null!;

    public virtual User? MovedByNavigation { get; set; }

    public virtual Bed ToBed { get; set; } = null!;
}
