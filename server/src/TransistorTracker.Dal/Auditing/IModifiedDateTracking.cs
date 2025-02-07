namespace TransistorTracker.Dal.Auditing;

internal interface IModifiedDateTracking
{
    public DateTime? ModifiedDate { get; set; }
}