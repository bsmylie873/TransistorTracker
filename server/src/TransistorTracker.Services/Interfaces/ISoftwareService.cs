using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Server.Interfaces;

public interface ISoftwareService
{
    IList<SoftwareDto> GetAllSoftware();
    IList<SoftwareCompatibilityDto> GetAllSoftwareCompatibilities();
    SoftwareDto? GetSoftwareById(int id);
    SoftwareCompatibilityDto? GetSoftwareCompatibilityById(int id);
    void CreateSoftware(CreateSoftwareDto software);
    void CreateSoftwareCompatibility(CreateSoftwareCompatibilityDto softwareCompatibility);
    bool UpdateSoftware(int id, UpdateSoftwareDto software);
    bool UpdateSoftwareCompatibility(int id, UpdateSoftwareCompatibilityDto softwareCompatibility);
    bool DeleteSoftware(int id);
    bool DeleteSoftwareCompatibility(int id);
}