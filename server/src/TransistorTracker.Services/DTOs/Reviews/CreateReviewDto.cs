namespace TransistorTracker.Server.DTOs.Reviews;

public class CreateReviewDto
{
    public string? ReviewText { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int? DeviceId { get; set; }
    public int? PartId { get; set; }
}