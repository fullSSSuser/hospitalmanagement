using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Payment
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = null!;

    public string? TransactionRef { get; set; }

    public DateTime PaidAt { get; set; }

    public Guid? ReceivedBy { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual User? ReceivedByNavigation { get; set; }
}
