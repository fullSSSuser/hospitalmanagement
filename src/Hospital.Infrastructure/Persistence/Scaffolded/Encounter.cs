using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Encounter
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public Guid? AppointmentId { get; set; }

    public DateTime VisitDate { get; set; }

    public string? ChiefComplaint { get; set; }

    public string? Notes { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? SignedAt { get; set; }

    public Guid? SignedBy { get; set; }

    public Guid? AmendmentOf { get; set; }

    public DateTime CreatedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Encounter? AmendmentOfNavigation { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual ICollection<AssignmentLog> AssignmentLogs { get; set; } = new List<AssignmentLog>();

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<EncounterTransfer> EncounterTransfers { get; set; } = new List<EncounterTransfer>();

    public virtual ICollection<Encounter> InverseAmendmentOfNavigation { get; set; } = new List<Encounter>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual User? SignedByNavigation { get; set; }

    public virtual ICollection<SubstanceConsumption> SubstanceConsumptions { get; set; } = new List<SubstanceConsumption>();

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();
}
