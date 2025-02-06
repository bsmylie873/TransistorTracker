namespace TransistorTracker.Server.DTOs.Software;

public class CreateSoftwareDto
{
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? Version { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public int CategoryId { get; set; }
}