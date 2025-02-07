using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Server.Profiles;

public class SoftwareProfile : Profile
{
    public SoftwareProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Software, SoftwareDto>();
        CreateMap<SoftwareCompatibility, SoftwareCompatibilityDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateSoftwareDto, Software>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<CreateSoftwareCompatibilityDto, SoftwareCompatibility>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<UpdateSoftwareDto, Software>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<UpdateSoftwareCompatibilityDto, SoftwareCompatibility>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}