using System;
using System.Collections.Generic;
using Hospital.Infrastructure.Persistence.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Persistence;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admission> Admissions { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AssignmentLog> AssignmentLogs { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<BedTransfer> BedTransfers { get; set; }

    public virtual DbSet<ChargeItem> ChargeItems { get; set; }

    public virtual DbSet<DebtRecord> DebtRecords { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Encounter> Encounters { get; set; }

    public virtual DbSet<EncounterTransfer> EncounterTransfers { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentPolicy> PaymentPolicies { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<ShiftPattern> ShiftPatterns { get; set; }

    public virtual DbSet<StockAlert> StockAlerts { get; set; }

    public virtual DbSet<Substance> Substances { get; set; }

    public virtual DbSet<SubstanceBatch> SubstanceBatches { get; set; }

    public virtual DbSet<SubstanceConsumption> SubstanceConsumptions { get; set; }

    public virtual DbSet<SubstanceImport> SubstanceImports { get; set; }

    public virtual DbSet<SubstanceLocation> SubstanceLocations { get; set; }

    public virtual DbSet<SubstanceStock> SubstanceStocks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vital> Vitals { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admissio__3214EC07E456D781");

            entity.ToTable("Admission");

            entity.HasIndex(e => e.BedId, "UX_Admission_ActiveBed")
                .IsUnique()
                .HasFilter("([Status]='Active')");

            entity.HasIndex(e => e.PatientId, "UX_Admission_ActivePatient")
                .IsUnique()
                .HasFilter("([Status]='Active')");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AdmittedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Bed).WithOne(p => p.Admission)
                .HasForeignKey<Admission>(d => d.BedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admission_Bed");

            entity.HasOne(d => d.DischargeOrderByNavigation).WithMany(p => p.AdmissionDischargeOrderByNavigations)
                .HasForeignKey(d => d.DischargeOrderBy)
                .HasConstraintName("FK_Admission_DischargeBy");

            entity.HasOne(d => d.Doctor).WithMany(p => p.AdmissionDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admission_Doctor");

            entity.HasOne(d => d.Patient).WithOne(p => p.Admission)
                .HasForeignKey<Admission>(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admission_Patient");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergy__3214EC078B84BAA5");

            entity.ToTable("Allergy");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Reaction).HasMaxLength(500);
            entity.Property(e => e.RecordedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Severity).HasMaxLength(20);
            entity.Property(e => e.Substance).HasMaxLength(200);

            entity.HasOne(d => d.Patient).WithMany(p => p.Allergies)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allergy_Patient");

            entity.HasOne(d => d.RecordedByNavigation).WithMany(p => p.Allergies)
                .HasForeignKey(d => d.RecordedBy)
                .HasConstraintName("FK_Allergy_RecordedBy");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC077D1B3809");

            entity.ToTable("Appointment");

            entity.HasIndex(e => e.SlotStart, "IX_Appointment_SlotStart");

            entity.HasIndex(e => new { e.DoctorId, e.SlotStart }, "UQ_Appointment_Doctor_Slot").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CancellationReason).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Booked");

            entity.HasOne(d => d.Department).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Department");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<AssignmentLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC07F0BAB2C1");

            entity.ToTable("AssignmentLog");

            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AssignmentLogs)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_AssignLog_Appointment");

            entity.HasOne(d => d.ChosenDoctor).WithMany(p => p.AssignmentLogs)
                .HasForeignKey(d => d.ChosenDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignLog_Doctor");

            entity.HasOne(d => d.Department).WithMany(p => p.AssignmentLogs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignLog_Department");

            entity.HasOne(d => d.Encounter).WithMany(p => p.AssignmentLogs)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK_AssignLog_Encounter");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC0782753EDC");

            entity.ToTable("AuditLog");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Entity).HasMaxLength(100);
            entity.Property(e => e.EntityId).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.UserAgent).HasMaxLength(500);

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AuditLog_User");
        });

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bed__3214EC07BEF2A330");

            entity.ToTable("Bed");

            entity.HasIndex(e => new { e.RoomId, e.Label }, "UQ_Bed_Room_Label").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Label).HasMaxLength(20);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available");

            entity.HasOne(d => d.Room).WithMany(p => p.Beds)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bed_Room");
        });

        modelBuilder.Entity<BedTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BedTrans__3214EC07991319A2");

            entity.ToTable("BedTransfer");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MovedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.Admission).WithMany(p => p.BedTransfers)
                .HasForeignKey(d => d.AdmissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BedTransfer_Admission");

            entity.HasOne(d => d.FromBed).WithMany(p => p.BedTransferFromBeds)
                .HasForeignKey(d => d.FromBedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BedTransfer_From");

            entity.HasOne(d => d.MovedByNavigation).WithMany(p => p.BedTransfers)
                .HasForeignKey(d => d.MovedBy)
                .HasConstraintName("FK_BedTransfer_By");

            entity.HasOne(d => d.ToBed).WithMany(p => p.BedTransferToBeds)
                .HasForeignKey(d => d.ToBedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BedTransfer_To");
        });

        modelBuilder.Entity<ChargeItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChargeIt__3214EC072157009A");

            entity.ToTable("ChargeItem");

            entity.HasIndex(e => e.Code, "UQ__ChargeIt__A25C5AA7FA4CAF73").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<DebtRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DebtReco__3214EC079CDC1A72");

            entity.ToTable("DebtRecord");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.Invoice).WithMany(p => p.DebtRecords)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Debt_Invoice");

            entity.HasOne(d => d.Patient).WithMany(p => p.DebtRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Debt_Patient");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07E707AFC4");

            entity.ToTable("Department");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F6C801E916").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deposit__3214EC073EEE4BDD");

            entity.ToTable("Deposit");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Method).HasMaxLength(20);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Deposit_Appointment");

            entity.HasOne(d => d.Patient).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deposit_Patient");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.ReceivedBy)
                .HasConstraintName("FK_Deposit_ReceivedBy");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diagnosi__3214EC074BB5CF85");

            entity.ToTable("Diagnosis");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ICD10Code).HasMaxLength(10);
            entity.Property(e => e.RecordedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagnosis_Encounter");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC07443A9DE1");

            entity.ToTable("Doctor");

            entity.HasIndex(e => e.Status, "IX_Doctor_Status");

            entity.HasIndex(e => e.UserId, "UQ__Doctor__1788CC4DFC4C62A1").IsUnique();

            entity.HasIndex(e => e.LicenseNumber, "UQ__Doctor__E889016687D488B8").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Specialty).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("OffShift");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Department");

            entity.HasOne(d => d.User).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_User");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorSc__3214EC07F8B7A06E");

            entity.ToTable("DoctorSchedule");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSchedule_Doctor");
        });

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encounte__3214EC0791B6DA76");

            entity.ToTable("Encounter");

            entity.HasIndex(e => new { e.PatientId, e.VisitDate }, "IX_Encounter_Patient_VisitDate").IsDescending(false, true);

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ChiefComplaint).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Draft");
            entity.Property(e => e.VisitDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.AmendmentOfNavigation).WithMany(p => p.InverseAmendmentOfNavigation)
                .HasForeignKey(d => d.AmendmentOf)
                .HasConstraintName("FK_Encounter_Amendment");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Encounter_Appointment");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encounter_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encounter_Patient");

            entity.HasOne(d => d.SignedByNavigation).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.SignedBy)
                .HasConstraintName("FK_Encounter_SignedBy");
        });

        modelBuilder.Entity<EncounterTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encounte__3214EC0761660355");

            entity.ToTable("EncounterTransfer");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.TransferredAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Encounter).WithMany(p => p.EncounterTransfers)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transfer_Encounter");

            entity.HasOne(d => d.FromDoctor).WithMany(p => p.EncounterTransferFromDoctors)
                .HasForeignKey(d => d.FromDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transfer_FromDoctor");

            entity.HasOne(d => d.ToDoctor).WithMany(p => p.EncounterTransferToDoctors)
                .HasForeignKey(d => d.ToDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transfer_ToDoctor");

            entity.HasOne(d => d.TransferredByNavigation).WithMany(p => p.EncounterTransfers)
                .HasForeignKey(d => d.TransferredBy)
                .HasConstraintName("FK_Transfer_By");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07323F188B");

            entity.ToTable("Insurance");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsPrimary).HasDefaultValue(true);
            entity.Property(e => e.PolicyNumber).HasMaxLength(100);
            entity.Property(e => e.Provider).HasMaxLength(200);

            entity.HasOne(d => d.Patient).WithMany(p => p.Insurances)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Insurance_Patient");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC070679DC07");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.InvoiceNumber, "UQ__Invoice__D776E9812F40DCA8").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(30);
            entity.Property(e => e.Paid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Open");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Admission).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AdmissionId)
                .HasConstraintName("FK_Invoice_Admission");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK_Invoice_Encounter");

            entity.HasOne(d => d.Patient).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Patient");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceL__3214EC0787D4A445");

            entity.ToTable("InvoiceLine");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount)
                .HasComputedColumnSql("([Quantity]*[UnitPrice])", true)
                .HasColumnType("decimal(29, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ChargeItem).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.ChargeItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLine_ChargeItem");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_InvoiceLine_Invoice");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC0778D72738");

            entity.ToTable("Patient");

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "IX_Patient_Name");

            entity.HasIndex(e => e.Phone, "IX_Patient_Phone");

            entity.HasIndex(e => e.MRN, "UQ__Patient__C790FDB4E2D7629B").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.EmergencyName).HasMaxLength(200);
            entity.Property(e => e.EmergencyPhone).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MRN).HasMaxLength(20);
            entity.Property(e => e.PatientType)
                .HasMaxLength(20)
                .HasDefaultValue("SelfPay");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PatientCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Patient_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PatientUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Patient_UpdatedBy");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC0701B33590");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Method).HasMaxLength(20);
            entity.Property(e => e.PaidAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.TransactionRef).HasMaxLength(100);

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Invoice");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReceivedBy)
                .HasConstraintName("FK_Payment_ReceivedBy");
        });

        modelBuilder.Entity<PaymentPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentP__3214EC0713BCAD03");

            entity.ToTable("PaymentPolicy");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BlockDischargeIfUnpaid).HasDefaultValue(true);
            entity.Property(e => e.DepositPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PatientType).HasMaxLength(20);

            entity.HasOne(d => d.Department).WithMany(p => p.PaymentPolicies)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Policy_Department");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC07D32D779B");

            entity.ToTable("Prescription");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Dose).HasMaxLength(100);
            entity.Property(e => e.Drug).HasMaxLength(200);
            entity.Property(e => e.Duration).HasMaxLength(100);
            entity.Property(e => e.Frequency).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Encounter).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Encounter");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC077336A7FA");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__737584F651872039").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC079BBE68EE");

            entity.ToTable("Room");

            entity.HasIndex(e => new { e.WardId, e.Number }, "UQ_Room_Ward_Number").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Number).HasMaxLength(20);

            entity.HasOne(d => d.Ward).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Ward");
        });

        modelBuilder.Entity<ShiftPattern>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShiftPat__3214EC0766E73D39");

            entity.ToTable("ShiftPattern");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MaxPatients).HasDefaultValue(30);
            entity.Property(e => e.SlotMinutes).HasDefaultValue(15);

            entity.HasOne(d => d.DoctorSchedule).WithMany(p => p.ShiftPatterns)
                .HasForeignKey(d => d.DoctorScheduleId)
                .HasConstraintName("FK_ShiftPattern_Schedule");
        });

        modelBuilder.Entity<StockAlert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockAle__3214EC07C05EB50F");

            entity.ToTable("StockAlert");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AlertType).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.ResolvedByNavigation).WithMany(p => p.StockAlerts)
                .HasForeignKey(d => d.ResolvedBy)
                .HasConstraintName("FK_StockAlert_User");

            entity.HasOne(d => d.Substance).WithMany(p => p.StockAlerts)
                .HasForeignKey(d => d.SubstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockAlert_Substance");
        });

        modelBuilder.Entity<Substance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC074DB5820A");

            entity.ToTable("Substance");

            entity.HasIndex(e => e.Code, "UQ__Substanc__A25C5AA7B292E70E").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(20);
        });

        modelBuilder.Entity<SubstanceBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC07B49FF9CC");

            entity.ToTable("SubstanceBatch");

            entity.HasIndex(e => new { e.SubstanceId, e.BatchNumber }, "UQ_SubstanceBatch").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BatchNumber).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(200);
            entity.Property(e => e.UnitCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Substance).WithMany(p => p.SubstanceBatches)
                .HasForeignKey(d => d.SubstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Batch_Substance");
        });

        modelBuilder.Entity<SubstanceConsumption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC07DA715AC5");

            entity.ToTable("SubstanceConsumption");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ConsumedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Batch).WithMany(p => p.SubstanceConsumptions)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumption_Batch");

            entity.HasOne(d => d.ConsumedByNavigation).WithMany(p => p.SubstanceConsumptions)
                .HasForeignKey(d => d.ConsumedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumption_User");

            entity.HasOne(d => d.Encounter).WithMany(p => p.SubstanceConsumptions)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumption_Encounter");

            entity.HasOne(d => d.Location).WithMany(p => p.SubstanceConsumptions)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumption_Location");

            entity.HasOne(d => d.Substance).WithMany(p => p.SubstanceConsumptions)
                .HasForeignKey(d => d.SubstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumption_Substance");
        });

        modelBuilder.Entity<SubstanceImport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC0786A08FFA");

            entity.ToTable("SubstanceImport");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ImportedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.SupplierInvoice).HasMaxLength(100);

            entity.HasOne(d => d.Batch).WithMany(p => p.SubstanceImports)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Import_Batch");

            entity.HasOne(d => d.ImportedByNavigation).WithMany(p => p.SubstanceImports)
                .HasForeignKey(d => d.ImportedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Import_User");

            entity.HasOne(d => d.Location).WithMany(p => p.SubstanceImports)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Import_Location");

            entity.HasOne(d => d.Substance).WithMany(p => p.SubstanceImports)
                .HasForeignKey(d => d.SubstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Import_Substance");
        });

        modelBuilder.Entity<SubstanceLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC077E9D655C");

            entity.ToTable("SubstanceLocation");

            entity.HasIndex(e => e.Name, "UQ__Substanc__737584F6D51CBD47").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<SubstanceStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Substanc__3214EC07E7E2E55C");

            entity.ToTable("SubstanceStock");

            entity.HasIndex(e => new { e.SubstanceId, e.BatchId, e.LocationId }, "UQ_SubstanceStock").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Batch).WithMany(p => p.SubstanceStocks)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Batch");

            entity.HasOne(d => d.Location).WithMany(p => p.SubstanceStocks)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Location");

            entity.HasOne(d => d.Substance).WithMany(p => p.SubstanceStocks)
                .HasForeignKey(d => d.SubstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Substance");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC073C5BEE07");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E42193B35D").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_User_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_User_UpdatedBy");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_Role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_User"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF2760AD3D71868E");
                        j.ToTable("UserRole");
                    });
        });

        modelBuilder.Entity<Vital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vitals__3214EC072749CFB8");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BloodPressure).HasMaxLength(20);
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.RecordedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Temperature).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vitals_Encounter");

            entity.HasOne(d => d.RecordedByNavigation).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.RecordedBy)
                .HasConstraintName("FK_Vitals_RecordedBy");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ward__3214EC0728385D63");

            entity.ToTable("Ward");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
