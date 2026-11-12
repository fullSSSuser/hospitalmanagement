using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class DebtRecord
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public string? Reason { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? SettledAt { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
