using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class AssignmentLog
{
    public long Id { get; set; }

    public Guid? AppointmentId { get; set; }

    public Guid? EncounterId { get; set; }

    public Guid DepartmentId { get; set; }

    public string CandidateIds { get; set; } = null!;

    public Guid ChosenDoctorId { get; set; }

    public string? ScoresJson { get; set; }

    public string? Reason { get; set; }

    public DateTime AssignedAt { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Doctor ChosenDoctor { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Encounter? Encounter { get; set; }
}
