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
        CreateMap<CreatePartDto, Part>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now));
        CreateMap<UpdatePartDto, Part>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));
    }
}