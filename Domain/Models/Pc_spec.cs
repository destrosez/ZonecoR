namespace Domain.Models;

public class Pc_spec
{
    public int seat_id { get; set; }

    public string? cpu { get; set; }

    public string? gpu { get; set; }

    public int? ram_gb { get; set; }

    public int? storage_gb { get; set; }

    public string? peripherals { get; set; }

    public string? extras { get; set; }

    public virtual Seat seat { get; set; } = null!;
}
