using AutoMapper;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Software;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Software;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class SoftwareService : ISoftwareService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public SoftwareService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService service)
    {
        (_database, _mapper, _paginationService) = (database, mapper, service);
    }
    
    public async Task<PaginatedDto<SoftwareDto>> GetAllSoftware(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var userQuery = _database
            .Get<Software>()
            .Where(new SoftwareBySearchSpec(searchQuery));

        var software = _mapper
            .ProjectTo<SoftwareDto>(userQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(software, pageSize, pageNumber);
    }
    
    public async Task<PaginatedDto<SoftwareCompatibilityDto>> GetAllSoftwareCompatibilities(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var softwareCompatibilityQuery = _database
            .Get<SoftwareCompatibility>()
            .Where(new SoftwareCompatibilitiesBySearchSpec(searchQuery));

        var softwareCompatibilities = _mapper
            .ProjectTo<SoftwareCompatibilityDto>(softwareCompatibilityQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(softwareCompatibilities, pageSize, pageNumber);
    }

    public async Task<SoftwareDto?> GetSoftwareById(int id)
    {
        var software = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));
        
        return await Task.FromResult(software == null ? null : _mapper.Map<SoftwareDto>(software));
    }
    
    public Task<SoftwareCompatibilityDto?> GetSoftwareCompatibilityById(int id)
    {
        var softwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        return Task.FromResult(softwareCompatibility == null ? null : _mapper.Map<SoftwareCompatibilityDto>(softwareCompatibility));
    }

    public async Task CreateSoftware(CreateSoftwareDto software)
    {
        var newSoftware = _mapper.Map<Software>(software);
        _database.Add(newSoftware);
        await _database.SaveChangesAsync();
    }
    
    public async Task CreateSoftwareCompatibility(CreateSoftwareCompatibilityDto softwareCompatibility)
    {
        var newSoftwareCompatibility = _mapper.Map<SoftwareCompatibility>(softwareCompatibility);
        _database.Add(newSoftwareCompatibility);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdateSoftware(int id, UpdateSoftwareDto software)
    {
        var currentSoftware = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));

        if (currentSoftware == null) return false;

        _mapper.Map(software, currentSoftware);
        await _database.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateSoftwareCompatibility(int id, UpdateSoftwareCompatibilityDto softwareCompatibility)
    {
        var currentSoftwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        if (currentSoftwareCompatibility == null) return false;

        _mapper.Map(softwareCompatibility, currentSoftwareCompatibility);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSoftware(int id)
    {
        var software = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));

        if (software == null) return false;

        _database.Delete(software);
        await _database.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteSoftwareCompatibility(int id)
    {
        var softwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        if (softwareCompatibility == null) return false;

        _database.Delete(softwareCompatibility);
        await _database.SaveChangesAsync();
        return true;
    }
}