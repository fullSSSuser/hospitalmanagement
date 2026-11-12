using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class PaymentPolicy
{
    public Guid Id { get; set; }

    public string PatientType { get; set; } = null!;

    public Guid? DepartmentId { get; set; }

    public bool RequiresDeposit { get; set; }

    public decimal? DepositPercent { get; set; }

    public bool BlockDischargeIfUnpaid { get; set; }

    public bool IsActive { get; set; }

    public virtual Department? Department { get; set; }
}
