namespace Domain.Models;

public partial class user
{
    public int id { get; set; }

    public string username { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public string? phone { get; set; }

    public bool is_active { get; set; }

    public DateTime created_at { get; set; }

    public virtual ICollection<audit_log> audit_logs { get; set; } = new List<audit_log>();

    public virtual ICollection<booking> bookings { get; set; } = new List<booking>();

    public virtual ICollection<role> roles { get; set; } = new List<role>();
}
