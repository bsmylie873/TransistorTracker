using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Server.Interfaces;

public interface ISoftwareService
{
    Task<PaginatedDto<SoftwareDto>> GetAllSoftware(PaginationDto pagination);
    Task<PaginatedDto<SoftwareCompatibilityDto>> GetAllSoftwareCompatibilities(PaginationDto pagination);
    Task<SoftwareDto?> GetSoftwareById(int id);
    Task<SoftwareCompatibilityDto?> GetSoftwareCompatibilityById(int id);
    Task CreateSoftware(CreateSoftwareDto software);
    Task CreateSoftwareCompatibility(CreateSoftwareCompatibilityDto softwareCompatibility);
    Task<bool> UpdateSoftware(int id, UpdateSoftwareDto software);
    Task<bool> UpdateSoftwareCompatibility(int id, UpdateSoftwareCompatibilityDto softwareCompatibility);
    Task<bool> DeleteSoftware(int id);
    Task<bool> DeleteSoftwareCompatibility(int id);
}