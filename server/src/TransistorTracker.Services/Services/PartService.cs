using AutoMapper;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Parts;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Parts;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EF6.Extensions;

namespace TransistorTracker.Server.Services;

public class PartService : IPartService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public PartService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService paginationService)
    {
        (_database, _mapper, _paginationService) = (database, mapper, paginationService);
    }
    
    public async Task<PaginatedDto<PartDto>> GetAllParts(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var partQuery = _database
            .Get<Part>()
            .Where(new PartsBySearchSpec(searchQuery));

        var parts = _mapper
            .ProjectTo<PartDto>(partQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(parts, pageSize, pageNumber);
    }

    public async Task<PartDto?> GetPartById(int id)
    {
        var part = await _database
            .Get<Part>()
            .FirstOrDefaultAsync(new PartByIdSpec(id));

        return _mapper.Map<PartDto>(part) ?? null;
    }

    public async Task CreatePart(CreatePartDto part)
    {
        var newPart = _mapper.Map<Part>(part);
        _database.Add(newPart);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdatePart(int id, UpdatePartDto part)
    {
        var currentPart = _database
            .Get<Part>()
            .FirstOrDefault(new PartByIdSpec(id));

        if (currentPart == null) return false;

        _mapper.Map(part, currentPart);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePart(int id)
    {
        var part = _database
            .Get<Part>()
            .FirstOrDefault(new PartByIdSpec(id));

        if (part == null) return false;

        _database.Delete(part);
        await _database.SaveChangesAsync();
        return true;
    }
}