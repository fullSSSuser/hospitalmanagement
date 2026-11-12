using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Doctor
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Specialty { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int EncountersToday { get; set; }

    public int AppointmentsToday { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Admission> AdmissionDischargeOrderByNavigations { get; set; } = new List<Admission>();

    public virtual ICollection<Admission> AdmissionDoctors { get; set; } = new List<Admission>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<AssignmentLog> AssignmentLogs { get; set; } = new List<AssignmentLog>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public virtual ICollection<EncounterTransfer> EncounterTransferFromDoctors { get; set; } = new List<EncounterTransfer>();

    public virtual ICollection<EncounterTransfer> EncounterTransferToDoctors { get; set; } = new List<EncounterTransfer>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual User User { get; set; } = null!;
}
