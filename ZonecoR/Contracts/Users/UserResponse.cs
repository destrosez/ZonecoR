namespace ZonecoR.Contracts.Users;

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedUtc { get; set; }
}