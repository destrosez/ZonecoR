namespace Domain.Models;

public class Audit_log
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public string action { get; set; } = null!;

    public string? details { get; set; }

    public DateTime? created_at { get; set; }

    public virtual User? user { get; set; }
}
