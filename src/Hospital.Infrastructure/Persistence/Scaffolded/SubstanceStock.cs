using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class SubstanceStock
{
    public Guid Id { get; set; }

    public Guid SubstanceId { get; set; }

    public Guid BatchId { get; set; }

    public Guid LocationId { get; set; }

    public int CurrentQuantity { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual SubstanceBatch Batch { get; set; } = null!;

    public virtual SubstanceLocation Location { get; set; } = null!;

    public virtual Substance Substance { get; set; } = null!;
}
