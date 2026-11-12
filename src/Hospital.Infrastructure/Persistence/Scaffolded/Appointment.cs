using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Appointment
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public Guid DepartmentId { get; set; }

    public DateTime SlotStart { get; set; }

    public DateTime SlotEnd { get; set; }

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public bool IsWalkIn { get; set; }

    public string? CancellationReason { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssignmentLog> AssignmentLogs { get; set; } = new List<AssignmentLog>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual Patient Patient { get; set; } = null!;
}
