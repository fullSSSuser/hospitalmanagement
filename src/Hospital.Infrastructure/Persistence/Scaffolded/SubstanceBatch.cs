using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class SubstanceBatch
{
    public Guid Id { get; set; }

    public Guid SubstanceId { get; set; }

    public string BatchNumber { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public string? SupplierName { get; set; }

    public decimal? UnitCost { get; set; }

    public virtual Substance Substance { get; set; } = null!;

    public virtual ICollection<SubstanceConsumption> SubstanceConsumptions { get; set; } = new List<SubstanceConsumption>();

    public virtual ICollection<SubstanceImport> SubstanceImports { get; set; } = new List<SubstanceImport>();

    public virtual ICollection<SubstanceStock> SubstanceStocks { get; set; } = new List<SubstanceStock>();
}
