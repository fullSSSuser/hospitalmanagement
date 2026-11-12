using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class SubstanceLocation
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<SubstanceConsumption> SubstanceConsumptions { get; set; } = new List<SubstanceConsumption>();

    public virtual ICollection<SubstanceImport> SubstanceImports { get; set; } = new List<SubstanceImport>();

    public virtual ICollection<SubstanceStock> SubstanceStocks { get; set; } = new List<SubstanceStock>();
}
