using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Locations;
using TransistorTracker.Server.DTOs.Locations;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EF6.Extensions;

namespace TransistorTracker.Server.Services;

public class LocationService : ILocationService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public LocationService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService paginationService)
    {
        (_database, _mapper, _paginationService) = (database, mapper, paginationService);
    }
    
    public async Task<PaginatedDto<LocationDto>> GetAllLocations(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var locationQuery = _database
            .Get<Location>()
            .Where(new LocationsBySearchSpec(searchQuery));

        var devices = _mapper
            .ProjectTo<LocationDto>(locationQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(devices, pageSize, pageNumber);
    }

    public async Task<LocationDto?> GetLocationById(int id)
    {
        var location = await _database
            .Get<Location>()
            .FirstOrDefaultAsync(new LocationByIdSpec(id));

        return _mapper.Map<LocationDto>(location) ?? null;
    }

    public async Task CreateLocation(CreateLocationDto location)
    {
        var newLocation = _mapper.Map<Location>(location);
        _database.Add(newLocation);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdateLocation(int id, UpdateLocationDto location)
    {
        var currentLocation = _database
            .Get<Location>()
            .FirstOrDefault(new LocationByIdSpec(id));

        if (currentLocation == null) return false;

        _mapper.Map(location, currentLocation);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        var location = _database
            .Get<Location>()
            .FirstOrDefault(new LocationByIdSpec(id));
        
        if (location == null) return false;
        
        _database.Delete(location);
        await _database.SaveChangesAsync();
        return true;
    }
}