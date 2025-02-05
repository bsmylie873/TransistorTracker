using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Locations;
using TransistorTracker.Server.DTOs.Locations;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class LocationService : ILocationService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public LocationService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<LocationDto> GetAllLocations()
    {
        var locationQuery = _database
            .Get<Location>();

        return _mapper
            .ProjectTo<LocationDto>(locationQuery)
            .ToList();
    }

    public LocationDto? GetLocationById(int id)
    {
        var location = _database
            .Get<Location>()
            .FirstOrDefault(new LocationByIdSpec(id));

        return _mapper.Map<LocationDto>(location) ?? null;
    }

    public void CreateLocation(CreateLocationDto location)
    {
        var newLocation = _mapper.Map<Location>(location);
        _database.Add(newLocation);
        _database.SaveChanges();
    }

    public bool UpdateLocation(int id, UpdateLocationDto location)
    {
        var currentLocation = _database
            .Get<Location>()
            .FirstOrDefault(new LocationByIdSpec(id));

        if (currentLocation == null) return false;

        _mapper.Map(location, currentLocation);
        _database.SaveChanges();
        return true;
    }

    public bool DeleteLocation(int id)
    {
        var location = _database
            .Get<Location>()
            .FirstOrDefault(new LocationByIdSpec(id));
        
        if (location == null) return false;
        
        _database.Delete(location);
        _database.SaveChanges();
        return true;
    }
}