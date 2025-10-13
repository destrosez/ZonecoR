namespace Domain.Models;

public class Payment
{
    public int id { get; set; }

    public int booking_id { get; set; }

    public decimal amount { get; set; }

    public string method { get; set; } = null!;

    public string status { get; set; } = null!;

    public DateTime? paid_at { get; set; }

    public string? external_id { get; set; }

    public virtual Booking booking { get; set; } = null!;
}
