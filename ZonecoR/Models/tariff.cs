using System;
using System.Collections.Generic;

namespace ZonecoR.Models;

public partial class tariff
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public decimal price_per_hour { get; set; }

    public bool is_active { get; set; }

    public DateOnly? valid_from { get; set; }

    public DateOnly? valid_to { get; set; }

    public virtual ICollection<booking> bookings { get; set; } = new List<booking>();
}
