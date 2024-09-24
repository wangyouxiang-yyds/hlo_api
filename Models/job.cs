using System;
using System.Collections.Generic;

namespace HLO_API.Models;

public partial class job
{
    public int JobId { get; set; }

    public string? JobName { get; set; }

    public virtual ICollection<character> character { get; set; } = new List<character>();
}
