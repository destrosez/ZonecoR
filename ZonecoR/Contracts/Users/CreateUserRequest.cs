namespace ZonecoR.Contracts.Users;

public class CreateUserRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
}