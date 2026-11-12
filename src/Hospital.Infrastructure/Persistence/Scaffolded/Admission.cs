using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Admission
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid BedId { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime AdmittedAt { get; set; }

    public DateTime? DischargedAt { get; set; }

    public string Status { get; set; } = null!;

    public Guid? DischargeOrderBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Bed Bed { get; set; } = null!;

    public virtual ICollection<BedTransfer> BedTransfers { get; set; } = new List<BedTransfer>();

    public virtual Doctor? DischargeOrderByNavigation { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Patient Patient { get; set; } = null!;
}
