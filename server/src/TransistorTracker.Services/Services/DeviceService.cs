using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Devices;
using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class DeviceService : IDeviceService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public DeviceService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<DeviceDto> GetAllDevices()
    {
        var deviceQuery = _database
            .Get<Device>();

        return _mapper
            .ProjectTo<DeviceDto>(deviceQuery)
            .ToList();
    }

    public DeviceDto? GetDeviceById(int id)
    {
        var device = _database
            .Get<Device>()
            .FirstOrDefault(new DeviceByIdSpec(id));

        return _mapper.Map<DeviceDto>(device) ?? null;
    }

    public void CreateDevice(CreateDeviceDto device)
    {
        var newDevice = _mapper.Map<Device>(device);
        _database.Add(newDevice);
        _database.SaveChanges();
    }

    public bool UpdateDevice(int id, UpdateDeviceDto device)
    {
        var currentDevice = _database
            .Get<Device>()
            .FirstOrDefault(new DeviceByIdSpec(id));

        if (currentDevice == null) return false;

        _mapper.Map(device, currentDevice);
        _database.SaveChanges();
        return true;
    }

    public bool DeleteDevice(int id)
    {
        var device = _database
            .Get<Device>()
            .FirstOrDefault(new DeviceByIdSpec(id));

        if (device == null) return false;

        _database.Delete(device);
        _database.SaveChanges();
        return true;
    }
}