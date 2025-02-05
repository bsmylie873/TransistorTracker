using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Parts;

namespace TransistorTracker.Server.Profiles;

public class PartProfile : Profile
{
    public PartProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }
    
    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Part, PartDto>();
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreatePartDto, Part>();
        CreateMap<UpdatePartDto, Part>();
    }
}