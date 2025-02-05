using AutoMapper;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Api.Profiles;

public class SoftwareProfile : Profile
{
    public SoftwareProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
    }
    
    private void ConfigureDtoToViewModel()
    {
        CreateMap<SoftwareDto, SoftwareViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateSoftwareViewModel, CreateSoftwareDto>();
        CreateMap<UpdateSoftwareViewModel, UpdateSoftwareDto>();
    }
}