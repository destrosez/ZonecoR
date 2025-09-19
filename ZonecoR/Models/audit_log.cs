using System;
using System.Collections.Generic;

namespace ZonecoR.Models;

public partial class audit_log
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public string action { get; set; } = null!;

    public string? details { get; set; }

    public DateTime? created_at { get; set; }

    public virtual user? user { get; set; }
}
