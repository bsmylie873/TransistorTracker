using TransistorTracker.Server.DTOs.Parts;

namespace TransistorTracker.Server.Interfaces;

public interface IPartService
{
    IList<PartDto> GetAllParts();
    PartDto? GetPartById(int id);
    void CreatePart(CreatePartDto part);
    bool UpdatePart(int id, UpdatePartDto part);
    bool DeletePart(int id);
}