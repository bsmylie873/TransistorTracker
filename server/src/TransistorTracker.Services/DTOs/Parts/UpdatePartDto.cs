namespace TransistorTracker.Server.DTOs.Parts;

public class UpdatePartDto
{
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? Description { get; set; }
    public int? Wattage { get; set; }
    public string? Colour { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public int? DeviceId { get; set; }
    public int? UserId { get; set; }
    public int? LocationId { get; set; }
    public int? CategoryId { get; set; }
    public int? ConditionId { get; set; }
    public int? StatusId { get; set; }
}