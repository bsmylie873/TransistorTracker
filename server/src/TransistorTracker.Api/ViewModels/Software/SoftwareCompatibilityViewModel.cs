namespace TransistorTracker.Api.ViewModels.Software;

public class SoftwareCompatibilityViewModel
{
    public int Id { get; set; }
    public int SoftwareId { get; set; }
    public int? PartId { get; set; }
    public int? DeviceId { get; set; }
    public int SoftwareCompatibilityLevelId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}