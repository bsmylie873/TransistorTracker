namespace TransistorTracker.Server.DTOs.Reviews;

public class ReviewDto
{
    public int Id { get; set; }
    public string? ReviewText { get; set; }
    public int Rating { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int UserId { get; set; }
    public int? DeviceId { get; set; }
    public int? PartId { get; set; }
}