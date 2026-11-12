using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class ShiftPattern
{
    public Guid Id { get; set; }

    public Guid DoctorScheduleId { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly ShiftStart { get; set; }

    public TimeOnly ShiftEnd { get; set; }

    public int SlotMinutes { get; set; }

    public int MaxPatients { get; set; }

    public virtual DoctorSchedule DoctorSchedule { get; set; } = null!;
}
