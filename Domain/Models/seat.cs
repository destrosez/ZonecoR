namespace Domain.Models;

public partial class seat
{
    public int id { get; set; }

    public int room_id { get; set; }

    public int number { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<booking> bookings { get; set; } = new List<booking>();

    public virtual pc_spec? pc_spec { get; set; }

    public virtual room room { get; set; } = null!;
}
