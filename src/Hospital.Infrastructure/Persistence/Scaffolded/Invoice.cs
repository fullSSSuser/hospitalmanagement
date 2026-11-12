using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Invoice
{
    public Guid Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public Guid PatientId { get; set; }

    public Guid? EncounterId { get; set; }

    public Guid? AdmissionId { get; set; }

    public decimal Total { get; set; }

    public decimal Paid { get; set; }

    public decimal Balance { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Admission? Admission { get; set; }

    public virtual ICollection<DebtRecord> DebtRecords { get; set; } = new List<DebtRecord>();

    public virtual Encounter? Encounter { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
