using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Substance
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string UnitOfMeasure { get; set; } = null!;

    public int ReorderLevel { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<StockAlert> StockAlerts { get; set; } = new List<StockAlert>();

    public virtual ICollection<SubstanceBatch> SubstanceBatches { get; set; } = new List<SubstanceBatch>();

    public virtual ICollection<SubstanceConsumption> SubstanceConsumptions { get; set; } = new List<SubstanceConsumption>();

    public virtual ICollection<SubstanceImport> SubstanceImports { get; set; } = new List<SubstanceImport>();

    public virtual ICollection<SubstanceStock> SubstanceStocks { get; set; } = new List<SubstanceStock>();
}
