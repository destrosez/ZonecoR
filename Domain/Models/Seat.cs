namespace Domain.Models;

public class Seat
{
    public int id { get; set; }

    public int room_id { get; set; }

    public int number { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<Booking> bookings { get; set; } = new List<Booking>();

    public virtual Pc_spec? pc_spec { get; set; }

    public virtual Room room { get; set; } = null!;
}
