using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class EncounterTransfer
{
    public Guid Id { get; set; }

    public Guid EncounterId { get; set; }

    public Guid FromDoctorId { get; set; }

    public Guid ToDoctorId { get; set; }

    public string? Reason { get; set; }

    public DateTime TransferredAt { get; set; }

    public Guid? TransferredBy { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual Doctor FromDoctor { get; set; } = null!;

    public virtual Doctor ToDoctor { get; set; } = null!;

    public virtual User? TransferredByNavigation { get; set; }
}
