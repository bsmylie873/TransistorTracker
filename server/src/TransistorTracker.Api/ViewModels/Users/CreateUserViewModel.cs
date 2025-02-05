namespace TransistorTracker.Api.ViewModels.Users;

public class CreateUserViewModel
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Avatar { get; set; }
    public int? UserTypeId { get; set; }
}