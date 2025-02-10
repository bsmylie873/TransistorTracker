using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Devices;
using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EF6.Extensions;

namespace TransistorTracker.Server.Services;

public class DeviceService : IDeviceService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public DeviceService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService paginationService)
    {
        (_database, _mapper, _paginationService) = (database, mapper, paginationService);
    }
    
    public async Task<PaginatedDto<DeviceDto>> GetAllDevices(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var deviceQuery = _database
            .Get<Device>()
            .Where(new DevicesBySearchSpec(searchQuery));

        var devices = _mapper
            .ProjectTo<DeviceDto>(deviceQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(devices, pageSize, pageNumber);
    }

    public async Task<DeviceDto?> GetDeviceById(int id)
    {
        var device = await _database
            .Get<Device>()
            .FirstOrDefaultAsync(new DeviceByIdSpec(id));

        return _mapper.Map<DeviceDto>(device) ?? null;
    }

    public async Task CreateDevice(CreateDeviceDto device)
    {
        var newDevice = _mapper.Map<Device>(device);
        _database.Add(newDevice);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdateDevice(int id, UpdateDeviceDto device)
    {
        var currentDevice = _database
            .Get<Device>()
            .FirstOrDefault(new DeviceByIdSpec(id));

        if (currentDevice == null) return false;

        _mapper.Map(device, currentDevice);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDevice(int id)
    {
        var device = _database
            .Get<Device>()
            .FirstOrDefault(new DeviceByIdSpec(id));

        if (device == null) return false;

        _database.Delete(device);
        await _database.SaveChangesAsync();
        return true;
    }
}