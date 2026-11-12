using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class SubstanceConsumption
{
    public Guid Id { get; set; }

    public Guid SubstanceId { get; set; }

    public Guid BatchId { get; set; }

    public Guid LocationId { get; set; }

    public Guid EncounterId { get; set; }

    public int Quantity { get; set; }

    public DateTime ConsumedAt { get; set; }

    public Guid ConsumedBy { get; set; }

    public virtual SubstanceBatch Batch { get; set; } = null!;

    public virtual User ConsumedByNavigation { get; set; } = null!;

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual SubstanceLocation Location { get; set; } = null!;

    public virtual Substance Substance { get; set; } = null!;
}
