using System;
using System.Collections.Generic;

namespace HLO_API.Models;

public partial class memberdata
{
    public int ID { get; set; }

    public string? Account { get; set; }

    public string? password { get; set; }

    public string? username { get; set; }

    public DateTime? createtime { get; set; }

    public string? GUID { get; set; }

    public virtual ICollection<character> character { get; set; } = new List<character>();
}
