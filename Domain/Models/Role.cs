namespace Domain.Models;

public class Role
{
    public int id { get; set; }

    public string code { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual ICollection<User> users { get; set; } = new List<User>();
}
