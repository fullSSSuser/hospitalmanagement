using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Deposit
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid? AppointmentId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = null!;

    public DateTime DepositedAt { get; set; }

    public Guid? ReceivedBy { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual User? ReceivedByNavigation { get; set; }
}
