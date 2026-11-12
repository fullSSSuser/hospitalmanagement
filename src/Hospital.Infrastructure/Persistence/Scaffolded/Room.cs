using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Room
{
    public Guid Id { get; set; }

    public Guid WardId { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Bed> Beds { get; set; } = new List<Bed>();

    public virtual Ward Ward { get; set; } = null!;
}
