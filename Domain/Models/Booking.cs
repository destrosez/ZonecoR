namespace Domain.Models;

public class Booking
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int seat_id { get; set; }

    public int? tariff_id { get; set; }

    public DateTime start_time { get; set; }

    public DateTime end_time { get; set; }

    public string status { get; set; } = null!;

    public decimal? total_amount { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual ICollection<Payment> payments { get; set; } = new List<Payment>();

    public virtual Seat seat { get; set; } = null!;

    public virtual Tariff? tariff { get; set; }

    public virtual User user { get; set; } = null!;
}
