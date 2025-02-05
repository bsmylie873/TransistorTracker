using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Parts;
using TransistorTracker.Server.DTOs.Parts;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class PartService : IPartService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public PartService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<PartDto> GetAllParts()
    {
        var partQuery = _database
            .Get<Part>();

        return _mapper
            .ProjectTo<PartDto>(partQuery)
            .ToList();
    }

    public PartDto? GetPartById(int id)
    {
        var part = _database
            .Get<Part>()
            .FirstOrDefault(new PartByIdSpec(id));

        return _mapper.Map<PartDto>(part) ?? null;
    }

    public void CreatePart(CreatePartDto part)
    {
        var newPart = _mapper.Map<Part>(part);
        _database.Add(newPart);
        _database.SaveChanges();
    }

    public bool UpdatePart(int id, UpdatePartDto part)
    {
        var currentPart = _database
            .Get<Part>()
            .FirstOrDefault(new PartByIdSpec(id));

        if (currentPart == null) return false;

        _mapper.Map(part, currentPart);
        _database.SaveChanges();
        return true;
    }

    public bool DeletePart(int id)
    {
        var part = _database
            .Get<Part>()
            .FirstOrDefault(new PartByIdSpec(id));

        if (part == null) return false;

        _database.Delete(part);
        _database.SaveChanges();
        return true;
    }
}