using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class StockAlert
{
    public Guid Id { get; set; }

    public Guid SubstanceId { get; set; }

    public string AlertType { get; set; } = null!;

    public string Message { get; set; } = null!;

    public bool IsResolved { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public Guid? ResolvedBy { get; set; }

    public virtual User? ResolvedByNavigation { get; set; }

    public virtual Substance Substance { get; set; } = null!;
}
