using System;
using System.Collections.Generic;

namespace HLO_API.Models;

public partial class character
{
    public int PlayerID { get; set; }

    public string PlayerName { get; set; } = null!;

    public int Level { get; set; }

    public float? HP { get; set; }

    public float? MP { get; set; }

    public double? Exp { get; set; }

    public int? JobId { get; set; }

    public int? RaceId { get; set; }

    public int? Coin { get; set; }

    public DateTime? CharacterCreateDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public int? BagCount { get; set; }

    public int? memberID { get; set; }

    public virtual job? Job { get; set; }

    public virtual race? Race { get; set; }

    public virtual memberdata? member { get; set; }
}
