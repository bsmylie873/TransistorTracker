using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Server.Interfaces;

public interface ISoftwareService
{
    IList<SoftwareDto> GetAllSoftware();
    SoftwareDto? GetSoftwareById(int id);
    void CreateSoftware(CreateSoftwareDto software);
    bool UpdateSoftware(int id, UpdateSoftwareDto software);
    bool DeleteSoftware(int id);
}