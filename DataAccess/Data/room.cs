using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities;

public partial class room
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<seat> seats { get; set; } = new List<seat>();
}
