using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Patient
{
    public Guid Id { get; set; }

    public string MRN { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public int? EstimatedAge { get; set; }

    public string Gender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? EmergencyName { get; set; }

    public string? EmergencyPhone { get; set; }

    public string PatientType { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Admission? Admission { get; set; }

    public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<DebtRecord> DebtRecords { get; set; } = new List<DebtRecord>();

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual User? UpdatedByNavigation { get; set; }
}
