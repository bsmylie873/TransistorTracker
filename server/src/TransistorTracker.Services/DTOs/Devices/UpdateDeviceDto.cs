namespace TransistorTracker.Server.DTOs.Devices;

public class UpdateDeviceDto
{
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string Model { get; set; } = null!;
    public int? Wattage { get; set; }
    public string? Colour { get; set; }
    public bool? Wireless { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public int UserId { get; set; }
    public int? LocationId { get; set; }
    public int ConditionId { get; set; }
    public int StatusId { get; set; }
    public int CategoryId { get; set; }
}