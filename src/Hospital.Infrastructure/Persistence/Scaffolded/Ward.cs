using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Ward
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
