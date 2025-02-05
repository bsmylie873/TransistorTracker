namespace TransistorTracker.Server.DTOs.Users;

public class UpdateUserDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Avatar { get; set; }
    public int? UserTypeId { get; set; }
}