using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class InvoiceLine
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public Guid ChargeItemId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public virtual ChargeItem ChargeItem { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;
}
