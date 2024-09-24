using System;
using System.Collections.Generic;

namespace HLO_API.Models;

public partial class race
{
    public int RaceId { get; set; }

    public string? RaceName { get; set; }

    public virtual ICollection<character> character { get; set; } = new List<character>();
}
