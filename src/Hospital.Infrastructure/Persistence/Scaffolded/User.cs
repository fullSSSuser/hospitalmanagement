using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<BedTransfer> BedTransfers { get; set; } = new List<BedTransfer>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<EncounterTransfer> EncounterTransfers { get; set; } = new List<EncounterTransfer>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUpdatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<Patient> PatientCreatedByNavigations { get; set; } = new List<Patient>();

    public virtual ICollection<Patient> PatientUpdatedByNavigations { get; set; } = new List<Patient>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<StockAlert> StockAlerts { get; set; } = new List<StockAlert>();

    public virtual ICollection<SubstanceConsumption> SubstanceConsumptions { get; set; } = new List<SubstanceConsumption>();

    public virtual ICollection<SubstanceImport> SubstanceImports { get; set; } = new List<SubstanceImport>();

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
