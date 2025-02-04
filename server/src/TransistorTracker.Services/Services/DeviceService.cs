using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Services;

public class DeviceService : IDeviceService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public DeviceService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IEnumerable<string> GetAllDevices()
    {
        throw new NotImplementedException();
    }

    public string GetDeviceById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateDevice(string device)
    {
        throw new NotImplementedException();
    }

    public void UpdateDevice(int id, string device)
    {
        throw new NotImplementedException();
    }

    public void DeleteDevice(int id)
    {
        throw new NotImplementedException();
    }
}