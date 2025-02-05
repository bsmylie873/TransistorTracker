using TransistorTracker.Server.DTOs.Locations;

namespace TransistorTracker.Server.Interfaces;

public interface ILocationService
{
    IList<LocationDto> GetAllLocations();
    LocationDto? GetLocationById(int id);
    void CreateLocation(CreateLocationDto location);
    bool UpdateLocation(int id, UpdateLocationDto location);
    bool DeleteLocation(int id);
}