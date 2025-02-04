using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Services;

public class PartService : IPartService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public PartService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IEnumerable<string> GetAllParts()
    {
        throw new NotImplementedException();
    }

    public string GetPartById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreatePart(string part)
    {
        throw new NotImplementedException();
    }

    public void UpdatePart(int id, string part)
    {
        throw new NotImplementedException();
    }

    public void DeletePart(int id)
    {
        throw new NotImplementedException();
    }
}