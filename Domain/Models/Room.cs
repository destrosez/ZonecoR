namespace Domain.Models;

public class Room
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<Seat> seats { get; set; } = new List<Seat>();
}
