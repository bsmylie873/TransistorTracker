using TransistorTracker.Server.DTOs.Locations;
using TransistorTracker.Server.DTOs.Pagination;

namespace TransistorTracker.Server.Interfaces;

public interface ILocationService
{
    Task<PaginatedDto<LocationDto>> GetAllLocations(PaginationDto paginationDto);
    Task<LocationDto?> GetLocationById(int id);
    Task CreateLocation(CreateLocationDto location);
    Task<bool> UpdateLocation(int id, UpdateLocationDto location);
    Task<bool> DeleteLocation(int id);
}