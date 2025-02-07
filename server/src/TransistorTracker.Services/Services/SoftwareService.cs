using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Software;
using TransistorTracker.Server.DTOs.Software;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class SoftwareService : ISoftwareService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public SoftwareService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<SoftwareDto> GetAllSoftware()
    {
        var userQuery = _database
            .Get<Software>();

        return _mapper
            .ProjectTo<SoftwareDto>(userQuery)
            .ToList();
    }
    
    public IList<SoftwareCompatibilityDto> GetAllSoftwareCompatibilities()
    {
        var softwareCompatibilities = _database
            .Get<SoftwareCompatibility>();

        return _mapper
            .ProjectTo<SoftwareCompatibilityDto>(softwareCompatibilities)
            .ToList();
    }

    public SoftwareDto? GetSoftwareById(int id)
    {
        var software = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));
        
        return software == null ? null : _mapper.Map<SoftwareDto>(software);
    }
    
    public SoftwareCompatibilityDto GetSoftwareCompatibilityById(int id)
    {
        var softwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        return _mapper.Map<SoftwareCompatibilityDto>(softwareCompatibility);
    }

    public void CreateSoftware(CreateSoftwareDto software)
    {
        var newSoftware = _mapper.Map<Software>(software);
        _database.Add(newSoftware);
        _database.SaveChanges();
    }
    
    public void CreateSoftwareCompatibility(CreateSoftwareCompatibilityDto softwareCompatibility)
    {
        var newSoftwareCompatibility = _mapper.Map<SoftwareCompatibility>(softwareCompatibility);
        _database.Add(newSoftwareCompatibility);
        _database.SaveChanges();
    }

    public bool UpdateSoftware(int id, UpdateSoftwareDto software)
    {
        var currentSoftware = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));

        if (currentSoftware == null) return false;

        _mapper.Map(software, currentSoftware);
        _database.SaveChanges();
        return true;
    }
    
    public bool UpdateSoftwareCompatibility(int id, UpdateSoftwareCompatibilityDto softwareCompatibility)
    {
        var currentSoftwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        if (currentSoftwareCompatibility == null) return false;

        _mapper.Map(softwareCompatibility, currentSoftwareCompatibility);
        _database.SaveChanges();
        return true;
    }

    public bool DeleteSoftware(int id)
    {
        var software = _database
            .Get<Software>()
            .FirstOrDefault(new SoftwareByIdSpec(id));

        if (software == null) return false;

        _database.Delete(software);
        _database.SaveChanges();
        return true;
    }
    
    public bool DeleteSoftwareCompatibility(int id)
    {
        var softwareCompatibility = _database
            .Get<SoftwareCompatibility>()
            .FirstOrDefault(new SoftwareCompatibilityByIdSpec(id));

        if (softwareCompatibility == null) return false;

        _database.Delete(softwareCompatibility);
        _database.SaveChanges();
        return true;
    }
}