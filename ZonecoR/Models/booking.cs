using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace ZonecoR.Models;

public partial class booking
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int seat_id { get; set; }

    public int? tariff_id { get; set; }

    public DateTime start_time { get; set; }

    public DateTime end_time { get; set; }

    public string status { get; set; } = null!;

    public decimal? total_amount { get; set; }

    public NpgsqlRange<DateTime>? period { get; set; }

    public virtual ICollection<payment> payments { get; set; } = new List<payment>();

    public virtual seat seat { get; set; } = null!;

    public virtual tariff? tariff { get; set; }

    public virtual user user { get; set; } = null!;
}
