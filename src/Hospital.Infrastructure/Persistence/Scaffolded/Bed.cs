using System;
using System.Collections.Generic;

namespace Hospital.Infrastructure.Persistence.Scaffolded;

public partial class Bed
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public string Label { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? LastCleanedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Admission? Admission { get; set; }

    public virtual ICollection<BedTransfer> BedTransferFromBeds { get; set; } = new List<BedTransfer>();

    public virtual ICollection<BedTransfer> BedTransferToBeds { get; set; } = new List<BedTransfer>();

    public virtual Room Room { get; set; } = null!;
}
