using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Parts;

namespace TransistorTracker.Server.Interfaces;

public interface IPartService
{
    Task<PaginatedDto<PartDto>> GetAllParts(PaginationDto pagination);
    Task<PartDto?> GetPartById(int id);
    Task CreatePart(CreatePartDto part);
    Task<bool> UpdatePart(int id, UpdatePartDto part);
    Task<bool> DeletePart(int id);
}