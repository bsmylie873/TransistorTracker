namespace TransistorTracker.Server.DTOs.Locations;

public class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? HouseNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}