using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Services;

public class LocationService : ILocationService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public LocationService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IEnumerable<string> GetAllLocations()
    {
        throw new NotImplementedException();
    }

    public string GetLocationById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateLocation(string location)
    {
        throw new NotImplementedException();
    }

    public void UpdateLocation(int id, string location)
    {
        throw new NotImplementedException();
    }

    public void DeleteLocation(int id)
    {
        throw new NotImplementedException();
    }
}