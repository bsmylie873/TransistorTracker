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
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateSoftwareDto, Software>();
        CreateMap<UpdateSoftwareDto, Software>();
    }
}