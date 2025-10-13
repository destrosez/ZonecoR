namespace Domain.Models;

public class User
{
    public int id { get; set; }

    public string username { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public string? phone { get; set; }

    public bool is_active { get; set; }

    public DateTime created_at { get; set; }

    public virtual ICollection<Audit_log> audit_logs { get; set; } = new List<Audit_log>();

    public virtual ICollection<Booking> bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Role> roles { get; set; } = new List<Role>();
}
