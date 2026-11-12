using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class SubstanceImport
{
    public Guid Id { get; set; }

    public Guid SubstanceId { get; set; }

    public Guid BatchId { get; set; }

    public Guid LocationId { get; set; }

    public int Quantity { get; set; }

    public DateTime ImportedAt { get; set; }

    public Guid ImportedBy { get; set; }

    public string? SupplierInvoice { get; set; }

    public virtual SubstanceBatch Batch { get; set; } = null!;

    public virtual User ImportedByNavigation { get; set; } = null!;

    public virtual SubstanceLocation Location { get; set; } = null!;

    public virtual Substance Substance { get; set; } = null!;
}
