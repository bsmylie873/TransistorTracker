using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Services;

public class SoftwareService : ISoftwareService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public SoftwareService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IEnumerable<string> GetAllSoftware()
    {
        throw new NotImplementedException();
    }

    public string GetSoftwareById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateSoftware(string software)
    {
        throw new NotImplementedException();
    }

    public void UpdateSoftware(int id, string software)
    {
        throw new NotImplementedException();
    }

    public void DeleteSoftware(int id)
    {
        throw new NotImplementedException();
    }
}